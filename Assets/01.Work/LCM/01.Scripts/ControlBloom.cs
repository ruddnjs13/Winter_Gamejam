using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ControlBloom : MonoBehaviour
{
    private Volume volume;
    private Bloom bloom;
    private float _colorValue = 1f;
    [SerializeField] private float _waitTime;
    private void Awake()
    {
        volume = GetComponent<Volume>();
        volume.profile.TryGet<Bloom>(out bloom);

        StartCoroutine(BloomChange());
    }

    private IEnumerator BloomChange(){
        for (int i = 0; i < 100; i++)
        {
            _colorValue -= 0.01f;
            bloom.tint.value = new Color(1, _colorValue, _colorValue, 1);
            yield return new WaitForSeconds(_waitTime);
        }
        for (int i = 0; i < 100; i++)
        {
            _colorValue += 0.01f;
            bloom.tint.value = new Color(1, _colorValue, _colorValue, 1);
            yield return new WaitForSeconds(_waitTime);
        }
        StartCoroutine(BloomChange());
    }
}
