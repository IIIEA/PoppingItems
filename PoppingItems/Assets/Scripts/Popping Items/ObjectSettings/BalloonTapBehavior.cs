using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

using DG.Tweening;

using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Test.ObjectSettings
{
    public class BalloonTapBehavior : SerializedMonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private Transform _sceneTransform;

        [SerializeField] private Vector3 _constrictionScale;
        [SerializeField] private Vector3 _increaseScale;
        [SerializeField] private float _duration;

        [OdinSerialize] private UnityEvent _onCompleteAnimation;

        public void Tap()
        {
            var sequence = DOTween.Sequence();

            sequence.Append(_sceneTransform.DOScale(_constrictionScale, _duration));
            sequence.Append(_sceneTransform.DOScale(_increaseScale, _duration)).AppendCallback(Callback);
        }

        private async void Callback()
        {
            _particleSystem.Play();
            _sceneTransform.gameObject.SetActive(false);

            await UniTask.WaitWhile(IsParticleSpawn);

            _onCompleteAnimation?.Invoke();
        }

        private bool IsParticleSpawn()
        {
            return _particleSystem.isPlaying;
        }
    }
}