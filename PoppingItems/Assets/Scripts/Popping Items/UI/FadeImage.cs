using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _targetFade;

    public void StartFade()
    {
        StartCoroutine(Fade()) ;
    }

    private IEnumerator Fade()
    {
        while(_canvasGroup.alpha <= _targetFade)
        {
            _canvasGroup.alpha = Mathf.MoveTowards(_canvasGroup.alpha, _targetFade, 0.1f);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
