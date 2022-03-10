using UnityEngine;
using UnityEngine.Events;

using Cysharp.Threading.Tasks;

namespace Test
{
    public class PointClickParticle : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particle;

        [SerializeField] private UnityEvent _animationEnded;

        public async void Play()
        {
            _particle.Play();

            await UniTask.Delay((int)_particle.main.duration * 1000);

            _animationEnded?.Invoke();
        }
    }
}
