using UnityEngine;
using UnityEngine.Events;

using Test.Interfaces;

namespace Test.ObjectSettings
{
    public class BalloonCheck : MonoBehaviour, ISubscribeActions
    {
        [SerializeField] private BalloonSettings balloonSettings;
        [SerializeField] private UnityEvent _onCheck;

        public void Check()
        {
            var isAnswer = balloonSettings.IsAnswer;

            if (!isAnswer)
                return;

            _onCheck?.Invoke();
        }

        public void Subscribe(UnityAction action)
        {
            _onCheck?.RemoveListener(action);

            _onCheck.AddListener(action);
        }
    }
}