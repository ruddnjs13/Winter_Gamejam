using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ControlBloom : MonoBehaviour
{
    private Volume volume;
    private Bloom bloom;
    [SerializeField] private int _count;
    [SerializeField] private float _waitTime;
    private void Awake()
    {
        volume = GetComponent<Volume>();
        volume.profile.TryGet<Bloom>(out bloom);

        StartCoroutine(BloomChange());
    }

    private IEnumerator BloomChange(){
        for (int i = 0; i < _count; i++)
        {
            bloom.intensity.value += 0.01f;
            yield return new WaitForSeconds(_waitTime);
        }
        for (int i = 0; i < _count; i++)
        {
            bloom.intensity.value -= 0.01f;
            yield return new WaitForSeconds(_waitTime);
        }
        StartCoroutine(BloomChange());
    }
}
