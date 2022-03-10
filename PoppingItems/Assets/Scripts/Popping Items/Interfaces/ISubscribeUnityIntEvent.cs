using UnityEngine.Events;

namespace Test.Interfaces
{
    public interface ISubscribeUnityIntEvent
    {
        void SubscribeUnityIntEvent(UnityAction<int> action);
        void SubscribersEvent();
    }
}