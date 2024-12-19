using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float attackRange = 1f;
    public Transform player;
    /*[SerializeField] private Material mat;
    private SpriteRenderer sprite;*/

    private int fadeHash;
    public float fadeDuration = 1f;

    private void Start()
    {
        //sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(WaitMove());
        //mat = sprite.material;
        //fadeHash = Shader.PropertyToID("_Fade");
        //mat.SetFloat(fadeHash, 1f);
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
        moveSpeed = 0;
        yield return new WaitForSeconds(1.8f);
        moveSpeed = 3f;
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
