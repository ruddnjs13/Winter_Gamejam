using UnityEngine;

public class DeatEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    private Influenza _influenza;

    public void InfluenzaDead(){
        _influenza = FindAnyObjectByType<Influenza>();
        Instantiate(_particle,_influenza.transform.position,Quaternion.identity);
    }
}
