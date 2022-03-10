using UnityEngine;

using Test.Extension;

namespace Test
{
    public class ProgressLine : MonoBehaviour, IStageComplete
    {
        private RectTransform _rectTransform;
        private int _count;
        private float _width;
        private ProgressLineExtension _lineExtension;

        public void Init(RectTransform rectTransform, float width, int count)
        {
            _lineExtension = new ProgressLineExtension(rectTransform);
            _rectTransform = rectTransform;
            _count = count;
            _width = width;
        }

        public void OnStageComplete(int stageCount)
        {
            var width = _width * (stageCount * 1f) / _count;
            _lineExtension.Expand(width);
        }
    }
}