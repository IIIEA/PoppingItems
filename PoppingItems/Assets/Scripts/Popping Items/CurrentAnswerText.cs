using Test.ObjectSettings;
using UnityEngine;
using UnityEngine.UI;

namespace Test
{
    public sealed class CurrentAnswerText : MonoBehaviour
    {
        [SerializeField] private Text _text;

        public void GetConditional(BalloonGameData balloonGameData)
        {
            var requireNumber = balloonGameData.Number;
            var isWantedNumber = balloonGameData.IsWantedNumber;

            var Answer = isWantedNumber ? $"with number {requireNumber}" : "";

            _text.text = $"Find balloon {Answer}";
        }
    }
}