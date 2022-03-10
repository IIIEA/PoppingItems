using UnityEngine;

using Sirenix.OdinInspector;

using Test.Extension;
using Test.Data;
using Test.ObjectSettings;

namespace Test
{
    public class ConditionalSettings : SerializedMonoBehaviour
    {
        [SerializeField] private UnityBalloonGameDataEvent _onSettingConditional;
        [SerializeField] private BalloonData _balloonData;
        [SerializeField] private bool _isWantedText;

        public void SetConditional()
        {
            var balloonColor = _balloonData.Colors.GetRandom();
            var number = GetNumber();
            var balloonGameData = new BalloonGameData(balloonColor, number, _isWantedText, false);

            _onSettingConditional?.Invoke(balloonGameData);
        }

        private string GetNumber()
        {
            var number = string.Empty;

            while (string.IsNullOrEmpty(number))
            {
                number = _balloonData.Numbers.GetRandom();
            }

            return number;
        }
    }
}
