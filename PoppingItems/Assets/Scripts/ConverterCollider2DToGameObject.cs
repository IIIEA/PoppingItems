using UnityEngine;

using Sirenix.OdinInspector;

using AmayaSoft.SimpleIoC.Modules.Signals.UnityEvents;

namespace Test
{
    public sealed class ConverterCollider2DToGameObject : SerializedMonoBehaviour
    {
        [SerializeField] private UnityGameObjectEvent _onConvert;

        public void Convert(Collider2D collider2D)
        {
            var convertedGameObject = collider2D.gameObject;
            _onConvert?.Invoke(convertedGameObject);
        }
    }
}