using UnityEngine;
using UnityEngine.Events;

using Sirenix.OdinInspector;

using Test.Interfaces;

using AmayaSoft.CoreFramework.UnityAPIExtensionsModule.UnityEventExtensions;

namespace Test
{
    public class ProgressCheckPointProxy : SerializedMonoBehaviour, ISubscribeUnityIntEvent
    {
        [SerializeField] private UnityIntEvent _onStageChange;
        [SerializeField] private UnityEvent _onComplete;

        private int _countStages;
        private float _countToChangeState;
        private int _currentCountCheckPoints = 0;
        private int _counter = 0;

        public void Init(int count, int countAllProgress)
        {
            _countStages = count;

            if (count != 0)
            {
                _countToChangeState = (float)countAllProgress / count;
            }
        }

        public void UpdateCheckPoints()
        {
            _onStageChange?.Invoke(_currentCountCheckPoints);
        }

        public void SubscribeUnityIntEvent(UnityAction<int> action)
        {
            _onStageChange.AddListener(action);
        }

        public void SubscribersEvent()
        {
            OnRightAnswer();
        }

        private void OnRightAnswer()
        {
            ++_counter;

            if (_counter >= _countToChangeState)
            {
                _counter = 0;
                _onStageChange?.Invoke(++_currentCountCheckPoints);
            }

            if (_currentCountCheckPoints != _countStages) return;

            _onComplete?.Invoke();
            _onComplete?.RemoveAllListeners();
            _onStageChange?.RemoveAllListeners();
        }
    }
}