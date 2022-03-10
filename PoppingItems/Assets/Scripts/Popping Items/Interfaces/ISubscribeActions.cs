using UnityEngine.Events;

namespace Test.Interfaces
{
    public interface ISubscribeActions
    {
        void Subscribe(UnityAction action);
    }
}