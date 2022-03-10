using UnityEngine;
using UnityEngine.Events;

using Sirenix.OdinInspector;

using Test.Interfaces;

using AmayaSoft.CoreFramework.UnityAPIExtensionsModule.UnityEventExtensions;

namespace Test
{
    public class ProgressLineProxy : SerializedMonoBehaviour, ISubscribeUnityIntEvent
    {
        [SerializeField] private UnityIntEvent _onStageChange;

        private int _countStages;
        private int _currentCountProgressLine = 0;

        public void Init(int count)
        {
            _countStages = count;
        }

        public void UpdateProgressLine()
        {
            _onStageChange?.Invoke(_currentCountProgressLine);
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
            _onStageChange?.Invoke(++_currentCountProgressLine);

            if (_currentCountProgressLine != _countStages) return;

            _onStageChange?.RemoveAllListeners();
        }
    }
}