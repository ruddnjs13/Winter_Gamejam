using System;
using UnityEngine;

public class ParentSmallPox : MonoBehaviour{
    [SerializeField] private GameObject child1;
    [SerializeField] private GameObject child2;
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Weapon"))
        {
            Instantiate(child1, new Vector2(transform.position.x + 1f, transform.position.y), Quaternion.identity);
            Instantiate(child2, new Vector2(transform.position.x - 1f, transform.position.y), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
