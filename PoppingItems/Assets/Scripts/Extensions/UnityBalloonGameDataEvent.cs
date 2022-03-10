using System;

using UnityEngine.Events;

using Test.ObjectSettings;

namespace Test.Extension
{
    [Serializable]
    public class UnityBalloonGameDataEvent : UnityEvent<BalloonGameData>
    {
    }
}