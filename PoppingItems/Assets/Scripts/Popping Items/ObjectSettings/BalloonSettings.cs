using UnityEngine;
using UnityEngine.Events;

using Sirenix.OdinInspector;
using Sirenix.Serialization;

using Test.Interfaces;

namespace Test.ObjectSettings
{
    public class BalloonSettings : SerializedMonoBehaviour, IChangeBalloonSettings, ISubscribeActions, IReset
    {
        [SerializeField] private Transform _sceneTransform;
        [SerializeField] private Collider2D _collider2D;
        [SerializeField] private SpriteRenderer _body;
        [SerializeField] private SpriteRenderer _tail;
        [SerializeField] private TextMesh _text;

        [OdinSerialize] private ISubscribeActions _balloonCheck;

        public bool IsAnswer { get; private set; }

        public void Change(BalloonGameData gameData)
        {
            _body.color = gameData.Color.BodyColor;
            _tail.color = gameData.Color.TailColor;
            _text.text = gameData.Number;
            IsAnswer = gameData.IsAnswer;
        }

        public void Subscribe(UnityAction action)
        {
            _balloonCheck.Subscribe(action);
        }

        public void Reset()
        {
            _sceneTransform.gameObject.SetActive(true);
            _sceneTransform.localScale = Vector3.one;
            _collider2D.enabled = true;
        }
    }
}