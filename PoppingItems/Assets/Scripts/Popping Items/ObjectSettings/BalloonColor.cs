using System;

using UnityEngine;

namespace Test.ObjectSettings
{
    [Serializable]
    public struct BalloonColor
    {
        [SerializeField] private string _colorName;
        [SerializeField] private Color _bodyColor;
        [SerializeField] private Color _tailColor;

        public string ColorName => _colorName;
        public Color BodyColor => _bodyColor;
        public Color TailColor => _tailColor;
    }
}
