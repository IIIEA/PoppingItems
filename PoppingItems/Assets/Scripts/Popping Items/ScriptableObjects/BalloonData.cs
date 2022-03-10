using System.Collections.Generic;

using UnityEngine;

using Test.ObjectSettings;

namespace Test.Data
{
    [CreateAssetMenu(fileName = "BalloonData", menuName = "ObjectSetting/Data/BalloonData")]
    public class BalloonData : ScriptableObject
    {
        [SerializeField] private List<BalloonColor> _colors;
        [SerializeField] private List<string> _numbers;

        public List<BalloonColor> Colors => _colors;
        public List<string> Numbers => _numbers;
    }
}