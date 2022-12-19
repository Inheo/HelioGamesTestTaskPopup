using UnityEngine;

namespace CodeBase.Logic
{
    [RequireComponent(typeof(CanvasGroup))]
    public class Popup : MonoBehaviour, ICoroutineRunner
    {
        [Min(0.1f)] public float AnimationDuration;

        private CanvasGroup _group;
        private CustomAnimation _animation;

        private void Awake()
        {
            _group = GetComponent<CanvasGroup>();
            _animation = new CustomAnimation(this);
        }

        public void Open()
        {
            if (_group.alpha == 1)
                return;
            _animation.Play(Open, AnimationDuration);
        }

        public void Close()
        {
            if (_group.alpha == 0)
                return;
            _animation.Play(Close, AnimationDuration);
        }

        private void Open(float time)
        {
            _group.alpha = time;
            LerpScale(Vector3.zero, Vector3.one, time);
        }

        private void Close(float time)
        {
            _group.alpha = 1 - time;
            LerpScale(Vector3.one, Vector3.zero, time);
        }

        private void LerpScale(Vector3 a, Vector3 b, float time)
        {
            transform.localScale = Vector3.Lerp(a, b, time);
        }
    }
}