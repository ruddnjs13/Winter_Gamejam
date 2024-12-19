using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public float attackRange = 1f;
    public Transform player;

    private int fadeHash;
    public float fadeDuration = 1f;

    private void Start()
    {
        moveSpeed = 6f;
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Destroy(gameObject);
            WaveManager.Instance.EnemyDefeated();
        }
    }

    private IEnumerator WaitMove()
    {
        moveSpeed = 0f;
        yield return new WaitForSeconds(2.5f);
        moveSpeed = 6f;
    }

    /*private IEnumerator ShaderCoroutine()
    {
        float fadeValue = 1f;

        while (fadeValue > 0)
        {
            fadeValue -= 0.1f; 
            fadeValue = Mathf.Max(fadeValue, 0); 

            mat.SetFloat(fadeHash, fadeValue);

            yield return new WaitForSeconds(fadeDuration / 10); 
        }

        mat.SetFloat(fadeHash, 0f);
        WaveManager.Instance.EnemyDefeated();
    }*/

}
