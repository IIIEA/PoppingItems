using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RestartButtonHandler : MonoBehaviour
{
    [SerializeField] private Button _restartButton;

    public event UnityAction Restarted;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        Restarted?.Invoke();
    }
}
