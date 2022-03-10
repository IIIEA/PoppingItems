using UnityEngine;

using Sirenix.OdinInspector;
using Sirenix.Serialization;

using AmayaSoft.CoreFramework.UtilsModule.Screens;
using AmayaSoft.SimpleIoC.Modules.Signals.UnityEvents;

namespace Test.Filter
{
    public class OutOfCameraPositionFilter : SerializedMonoBehaviour
    {
        [OdinSerialize] private UnityGameObjectEvent _onOutOfCamera;
        [SerializeField] private float _radius;
        [SerializeField] private bool _xAxis;
        [SerializeField] private bool _yAxis;
        private Vector2 _position;

        public void CheckGameObject(GameObject gameObject)
        {
            _position = gameObject.transform.position;

            if (IsOnOfCamera())
                return;

            _onOutOfCamera?.Invoke(gameObject);
        }

        private bool IsOnOfCamera()
        {
            var screenBounds = ScreenBounds.GetScreenBounds();

            var isOutFromLeftSide = _position.x + _radius < screenBounds.min.x;
            var isOutFromBottomSide = _position.y + _radius < screenBounds.min.y;
            var isOutFromRightSide = _position.x - _radius > screenBounds.max.x;
            var isOutFromTopSide = _position.y - _radius > screenBounds.max.y;

            isOutFromRightSide = _xAxis && isOutFromRightSide;
            isOutFromLeftSide = _xAxis && isOutFromLeftSide;

            isOutFromBottomSide = _yAxis && isOutFromBottomSide;
            isOutFromTopSide = _yAxis && isOutFromTopSide;

            return !(isOutFromLeftSide || isOutFromBottomSide ||
                         isOutFromRightSide || isOutFromTopSide);
        }

        private void OnDrawGizmos()
        {
            var screenBounds = ScreenBounds.GetScreenBounds();

            var min = screenBounds.min;
            var max = screenBounds.max;

            var LeftDown = new Vector2(min.x, min.y);
            var LeftUp = new Vector2(min.x, max.y);
            var RightDown = new Vector2(max.x, min.y);
            var RightUp = new Vector2(max.x, max.y);

            Gizmos.DrawLine(LeftDown, RightDown);
            Gizmos.DrawLine(LeftUp, RightUp);
            Gizmos.DrawLine(LeftDown, LeftUp);
            Gizmos.DrawLine(RightDown, RightUp);
        }
    }
}