using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class SpawnPoints : MonoBehaviour
    {
        [SerializeField] private Vector2 _startPosition;
        [SerializeField] private float _borderOffsetX;
        [SerializeField] private float _offsetX;

        private float _width;
        private float _randomPositionX = 0;

        private Vector2 _currentPosition;
        private Vector2 _minPositionX;
        private Vector2 _maxPositionX;

        private void Awake()
        {
            _width = Camera.main.pixelWidth;
            _currentPosition = _startPosition;
        }

        public void InitializeSpawnPositions()
        {
            _minPositionX = Camera.main.ScreenToWorldPoint(new Vector2(0, _startPosition.y));
            _maxPositionX = Camera.main.ScreenToWorldPoint(new Vector2(_width, _startPosition.y));

            _minPositionX.x += _borderOffsetX;
            _maxPositionX.x -= _borderOffsetX;
        }

        public void SetPosition(GameObject item)
        {
            while (_randomPositionX >= _currentPosition.x - _offsetX && _randomPositionX <= _currentPosition.x + _offsetX)
            {
                _randomPositionX = Random.Range(_minPositionX.x, _maxPositionX.x);
            }

            _currentPosition = new Vector2(_randomPositionX, _startPosition.y);

            item.transform.position = _currentPosition;
        }
    }
}
