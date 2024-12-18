using UnityEngine;

public class ReloadUI : MonoBehaviour
{
    [SerializeField] private GameObject _bar;

    public void SetValue(float value)
    {
        _bar.transform.localScale = new Vector3(value, 1, 1);
    }
}
