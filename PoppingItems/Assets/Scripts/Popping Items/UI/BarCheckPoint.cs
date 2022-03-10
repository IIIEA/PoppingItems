using UnityEngine;
using UnityEngine.UI;

using Test.Extension;

namespace Test
{
    public class BarCheckPoint : MonoBehaviour, IStageComplete
    {
        private int _targetStage;
        private Sprite _completeCheckPoint;
        private Image _image;
        private ParticleSystem _particleSystem;

        public void Init(int stage, Sprite sprite, ParticleSystem particle, Image image)
        {
            _targetStage = stage;
            _completeCheckPoint = sprite;
            _image = image;
            _particleSystem = Instantiate(particle, transform);
        }

        public void OnStageComplete(int stage)
        {
            if (stage != _targetStage)
            {
                return;
            }

            _image.SetSprite(_completeCheckPoint);
            _particleSystem.Play();
        }
    }
}