using System.Collections;
using UnityEngine;

namespace CodeBase.Logic
{
    [RequireComponent(typeof(RectTransform))]
    public class SizeRelativeLastChild : MonoBehaviour
    {
        [System.Flags]
        public enum Fit
        {
            Horizontal = 1,
            Vertical
        }

        public Fit FitSide;
        public Vector2 Padding;

        private RectTransform _rectTransform;

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            ToFitWithDelay();
        }

        public void ToFit()
        {
            _rectTransform = _rectTransform == null ? GetComponent<RectTransform>() : _rectTransform;

            Vector2 size = Vector3.zero;

            if (transform.childCount == 0)
                return;

            RectTransform lastChild = transform.GetChild(transform.childCount - 1).GetComponent<RectTransform>();

            size.x = Mathf.Abs(lastChild.sizeDelta.x) + Mathf.Abs(lastChild.anchoredPosition.x);
            size.y = Mathf.Abs(lastChild.sizeDelta.y) + Mathf.Abs(lastChild.anchoredPosition.y);
            size += Padding;

            size.x = (FitSide & Fit.Horizontal) != 0 ? size.x : _rectTransform.sizeDelta.x;
            size.y = (FitSide & Fit.Vertical) != 0 ? size.y : _rectTransform.sizeDelta.y;

            _rectTransform.sizeDelta = size;
        }

        private void ToFitWithDelay()
        {
            StartCoroutine(ToFitFor());
        }

        private IEnumerator ToFitFor()
        {
            yield return null;
            ToFit();
            yield return null;
            ToFit();
        }
    }
}