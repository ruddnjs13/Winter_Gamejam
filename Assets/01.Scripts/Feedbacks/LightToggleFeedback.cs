using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightToggleFeedback : Feedback
{
    [SerializeField] private float _blinkTime = 0.05f;
    [SerializeField] private Light2D _targetLight;

    private WaitForSeconds _ws;

    private void Awake()
    {
        _ws = new WaitForSeconds(_blinkTime);
    }

    public override void PlayFeedback()
    {
        StartCoroutine(ToggleCoroutine());
    }

    private IEnumerator ToggleCoroutine()
    {
        _targetLight.enabled = true;
        yield return _ws;
        _targetLight.enabled = false;
    }

    public override void StopFeedback()
    {
        StopAllCoroutines();
    }
}
