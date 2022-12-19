using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CodeBase.Logic
{
    public class CustomButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, ICoroutineRunner
    {
        [Min(0.1f)] public float AnimationDuration = 1f;
        [SerializeField] private TextMeshProUGUI _text;

        [Header("Normal State")]
        [SerializeField] private Image _normalImage;
        [SerializeField] private Color _normalTextColor;


        [Header("Click State")]
        [SerializeField] private Image _clickImage;
        [SerializeField] private Color _clickTextColor;

        [Space]
        public UnityEvent OnClick;

        private CustomAnimation _animation;

        private void Start()
        {
            _animation = new CustomAnimation(this);
            ToNormalState(1);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke();
        }

        private void ToNormalState(float time)
        {
            _clickImage.color = Color.Lerp(Color.white, new Color(1, 1, 1, 0), time);
            _normalImage.color = Color.Lerp(Color.white, new Color(1, 1, 1, 0), 1 - time);

            _text.color = Color.Lerp(_clickTextColor, _normalTextColor, time);
        }

        private void ToClickState(float time)
        {
            _normalImage.color = Color.Lerp(Color.white, new Color(1, 1, 1, 0), time);
            _clickImage.color = Color.Lerp(Color.white, new Color(1, 1, 1, 0), 1 - time);

            _text.color = Color.Lerp(_normalTextColor, _clickTextColor, time);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _animation.Play(ToClickState, AnimationDuration);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _animation.Play(ToNormalState, AnimationDuration);
        }
    }
}