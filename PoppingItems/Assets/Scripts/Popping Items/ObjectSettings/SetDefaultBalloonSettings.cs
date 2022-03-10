using UnityEngine;
using UnityEngine.Assertions;

using Test.Interfaces;

namespace Test.ObjectSettings
{
    public class SetDefaultBalloonSettings : MonoBehaviour
    {
        public void SetDefault(GameObject gameObject)
        {
            var resetComponent = gameObject.GetComponent<IReset>();
            Assert.IsNotNull(resetComponent, "GameObject not contain IReset");

            resetComponent.Reset();
        }
    }
}