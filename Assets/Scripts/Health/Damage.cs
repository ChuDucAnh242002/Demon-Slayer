using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private GameObject targetObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == targetObject.tag){
            Health collisionObjectHealth = collision.gameObject.GetComponent<Health>();
            if(collisionObjectHealth == null){
                return;
            }
            collisionObjectHealth.TakeDamage(damage);
        }
    }
}
