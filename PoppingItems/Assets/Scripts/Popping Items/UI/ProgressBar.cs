using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Sirenix.Serialization;
using Sirenix.OdinInspector;

using Test.Extension;
using Test.Data;

namespace Test
{
    [RequireComponent(typeof(Image))]
    public sealed class ProgressBar : SerializedMonoBehaviour
    {
        [SerializeField] private ProgressBarData _progressBarData;
        [SerializeField] private Vector2 _progressLinePivot;
        [OdinSerialize] private ProgressCheckPointProxy _progressCheckPoitnProxy;
        [OdinSerialize] private ProgressLineProxy _progressLineProxy;

        [Button]
        public void Initialize()
        {
            Remove();

            var barScene = _progressBarData.Bar;
            var progressLine = _progressBarData.ProgressLine;
            var checkPointScene = _progressBarData.CheckPoint;
            var completeCheckPoint = _progressBarData.CompleteCheckPoint;
            var checkPointStates = _progressBarData.CheckPointStates;
            var progressLineStates = _progressBarData.ProgressCheckPointStates;
            var leftOffset = _progressBarData.LeftLineOffset;
            var particle = _progressBarData.ParticleSystem;

            var statusBarImage = GetComponent<Image>();

            statusBarImage.SetSprite(barScene);

            CreateProgressLine(progressLine, statusBarImage, leftOffset, progressLineStates);

            for (var i = 1; i <= checkPointStates; i++)
            {
                CreateCheckPoints(i, checkPointStates, statusBarImage, checkPointScene, completeCheckPoint, particle);
            }

            _progressLineProxy.Init(progressLineStates);
            _progressCheckPoitnProxy.Init(checkPointStates, progressLineStates);
        }

        public void UpdateStatus()
        {
            _progressCheckPoitnProxy.UpdateCheckPoints();
            _progressLineProxy.UpdateProgressLine();
        }

        private void CreateProgressLine(Sprite line, Image bar, float leftOffset, int states)
        {
            var progressLine = new GameObject();

            progressLine.name = line.name;

            var width = bar.rectTransform.sizeDelta.x;
            var imageComponent = progressLine.AddComponent<Image>();
            var position = Vector2.right * (leftOffset - width / 2);

            var component = progressLine.AddComponent<ProgressLine>();

            component.Init(imageComponent.rectTransform, width, states);

            _progressLineProxy.SubscribeUnityIntEvent(component.OnStageComplete);

            SetImageSettings(imageComponent, bar.transform, position, _progressLinePivot, line);
        }

        private void CreateCheckPoints(int startCount, int endCount, Image bar, Sprite sprite, Sprite completeSprite, ParticleSystem particleSystem)
        {
            var percentPosition = startCount * 1f / endCount;
            var width = bar.rectTransform.sizeDelta.x;
            var position = Vector3.right * width * (percentPosition - 0.5f);
            var checkPoint = new GameObject();

            checkPoint.name = sprite.name;

            var component = checkPoint.AddComponent<BarCheckPoint>();
            var imageComponent = checkPoint.AddComponent<Image>();

            component.Init(startCount, completeSprite, particleSystem, imageComponent);

            _progressCheckPoitnProxy.SubscribeUnityIntEvent(component.OnStageComplete);

            SetImageSettings(imageComponent, bar.transform, position, Vector2.one / 2, sprite);
        }

        private void SetImageSettings(Image image, Transform parent, Vector2 position, Vector2 pivot, Sprite sprite)
        {
            image.rectTransform.SetParent(parent);
            image.rectTransform.pivot = pivot;
            image.rectTransform.anchoredPosition = position;
            image.type = Image.Type.Tiled;
            image.SetSprite(sprite);
        }

        private void Remove()
        {
            var childCount = gameObject.transform.childCount;
            var childTransforms = new List<Transform>();

            for (var i = 0; i < childCount; i++)
            {
                childTransforms.Add(transform.GetChild(i));
            }

            foreach (var childTransform in childTransforms)
            {
                DestroyImmediate(childTransform.gameObject);
            }
        }
    }
}