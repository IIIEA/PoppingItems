using UnityEngine;

namespace Test.Data
{
    [CreateAssetMenu(fileName = "ProgressBarData", menuName = "Bar/Data/ProgressBarData", order = 51)]
    public class ProgressBarData : ScriptableObject
    {
        [SerializeField] private Sprite _progressBar;
        [SerializeField] private Sprite _progressLine;
        [SerializeField] private Sprite _checkPoint;
        [SerializeField] private Sprite _completeCheckPoint;
        [SerializeField, Range(1, 10)] private int _checkPointStates;
        [SerializeField, Range(1, 10)] private int _progressCheckPointStates;
        [SerializeField] private float _rightLineOffset;
        [SerializeField] private float _leftLineOffset;
        [SerializeField] private ParticleSystem _particleSystem;

        private void OnValidate()
        {
            if(_progressCheckPointStates % _checkPointStates != 0)
            {
                _progressCheckPointStates = _checkPointStates;
            }
        }

        public Sprite Bar => _progressBar;
        public Sprite CompleteCheckPoint => _completeCheckPoint;
        public Sprite CheckPoint => _checkPoint;
        public Sprite ProgressLine => _progressLine;
        public int CheckPointStates => _checkPointStates;
        public int ProgressCheckPointStates => _progressCheckPointStates;
        public float RightLineOffset => _rightLineOffset;
        public float LeftLineOffset => _leftLineOffset;

        public ParticleSystem ParticleSystem => _particleSystem;
    }
}
