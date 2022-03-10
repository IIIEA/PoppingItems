using UnityEngine;
using UnityEngine.Assertions;

using Sirenix.OdinInspector;
using Sirenix.Serialization;

using Test.Interfaces;

namespace Test.ObjectSettings
{
    public class BalloonSubscriber : SerializedMonoBehaviour
    {
        [OdinSerialize] private ISubscribeUnityIntEvent _progressBar;
        [OdinSerialize] private ISubscribeUnityIntEvent _progressLine;

        public void Subscribe(GameObject spawnedObject)
        {
            var subscriber = spawnedObject.GetComponent<ISubscribeActions>();
            Assert.IsNotNull(subscriber, "Spawned object not contain ISubscribeActions");

            subscriber.Subscribe(_progressBar.SubscribersEvent);
            subscriber.Subscribe(_progressLine.SubscribersEvent);
        }
    }
}