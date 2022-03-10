using UnityEngine;

using DG.Tweening;

namespace Test.Extension
{
    public class ProgressLineExtension
    {
        public ProgressLineExtension(RectTransform rectTransform)
        {
            _rectTransform = rectTransform;
            _sequence = DOTween.Sequence();
        }

        private RectTransform _rectTransform;
        private Sequence _sequence;

        public void Expand(float width)
        {
            DOTween.KillAll();

            var towardSize = new Vector2(width, _rectTransform.sizeDelta.y);
            _sequence.Append(_rectTransform.DOSizeDelta(towardSize, 1));
        }
    }
}