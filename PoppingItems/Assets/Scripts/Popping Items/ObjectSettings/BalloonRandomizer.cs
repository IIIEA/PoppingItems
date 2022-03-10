using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

using Sirenix.OdinInspector;
using Sirenix.Serialization;

using Test.Extension;
using Test.Data;
using Test.Interfaces;

using AmayaSoft.CoreFramework.FiltersModule;
using AmayaSoft.CoreFramework.SpawnerModule;

namespace Test.ObjectSettings
{
    public class BalloonRandomizer : SerializedMonoBehaviour
    {
        [SerializeField] private BalloonData _balloonData;
        [OdinSerialize] private ISpawnerBehaviour<GameObject> _spawnerBehaviour;
        [OdinSerialize] private IFilterBehaviour _filter;

        private BalloonGameData _answerBalloonGameData;

        public void SetRightBalloonSettings(BalloonGameData gameData)
        {
            _answerBalloonGameData = gameData;
        }

        public void RandomizeBalloon(GameObject spawnedObject)
        {
            var changeSettings = spawnedObject.GetComponent<IChangeBalloonSettings>();
            Assert.IsNotNull(changeSettings, "Spawned object not contain IChangeBalloonSettings");

            var subscriber = spawnedObject.GetComponent<ISubscribeActions>();
            Assert.IsNotNull(subscriber, "Spawned object not contain ISubscribeActions");

            var isAnswer = _filter.IsPermitted();
            var randomColor = GetElement(isAnswer, _answerBalloonGameData.Color,
                _balloonData.Colors);
            var randomNumber = GetElement(isAnswer, _answerBalloonGameData.IsWantedNumber, _answerBalloonGameData.Number,
                _balloonData.Numbers);

            var balloonGameData = new BalloonGameData(randomColor, randomNumber, isAnswer);

            changeSettings.Change(balloonGameData);
        }

        private T GetElement<T>(bool isAnswer, bool isRequire, T answer, List<T> listElements)
        {
            if (isAnswer && isRequire)
                return answer;

            return GetRandomElementWithoutAnswer(listElements, answer);
        }

        private T GetElement<T>(bool isAnswer, T answer, List<T> listElements)
        {
            if (isAnswer)
                return answer;

            return GetRandomElementWithoutAnswer(listElements, answer);
        }

        private T GetRandomElementWithoutAnswer<T>(List<T> list, T removeAnswer)
        {
            var currentList = new List<T>();
            currentList.AddRange(list);
            currentList.Remove(removeAnswer);

            return currentList.GetRandom();
        }
    }
}