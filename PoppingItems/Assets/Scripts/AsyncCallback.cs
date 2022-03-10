using UnityEngine;
using UnityEngine.Events;

using Sirenix.OdinInspector;
using Sirenix.Serialization;

using Cysharp.Threading.Tasks;

using AmayaSoft.CoreFramework.FiltersModule;

namespace Test
{
    public class AsyncCallback : SerializedMonoBehaviour
    {
        [OdinSerialize] private IFilterBehaviour _filterBehaviour;
        [SerializeField] private UnityEvent _onAsyncCall;

        private bool _isLoop;

        public async void StartLoop()
        {
            _isLoop = true;

            while (_isLoop)
            {
                await UniTask.WaitUntil(() => _filterBehaviour.IsPermitted());
                _onAsyncCall?.Invoke();
            }
        }

        public void Dispose()
        {
            _isLoop = false;
            _onAsyncCall.RemoveAllListeners();
        }
    }
}