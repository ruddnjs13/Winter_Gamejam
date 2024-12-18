using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float attackRange = 1f;
    public Transform player;
    [SerializeField] private Material mat;

    private int fadeHash;
    public float fadeDuration = 1f;

    private void Awake()
    {
        Debug.Log(1);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(2);
        fadeHash = Shader.PropertyToID("_Fade");
        Debug.Log(3);
        mat.SetFloat("_Fade", 1f);
        Debug.Log(4);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Destroy(gameObject);
            //PoolManager.Instance.Push(this);
            WaveManager.Instance.EnemyDefeated();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            StartCoroutine(ShaderCoroutine());
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator ShaderCoroutine()
    {
        float fadeValue = 1f;

        while (fadeValue > 0)
        {
            fadeValue -= 0.1f; 
            fadeValue = Mathf.Max(fadeValue, 0); 

            mat.SetFloat("_Fade", fadeValue);

            yield return new WaitForSeconds(fadeDuration / 10); 
        }

        mat.SetFloat("_Fade", 0f);
        WaveManager.Instance.EnemyDefeated();
    }

}
