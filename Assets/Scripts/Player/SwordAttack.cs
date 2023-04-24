using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField] private float damage = 5;
    private BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void Attack(){
        boxCollider2D.enabled = true;
    }

    public void StopAttack(){
        boxCollider2D.enabled = false;
    }

    public void ChangeSwordDirection(Vector2 input){
        if(input.x == 1){
            transform.localScale = new Vector3 (1f, 1f, 1f);
        } else if (input.x == -1){
            transform.localScale = new Vector3 (-1f, 1f, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Enemy"){
            Health collisionObjectHealth = collision.gameObject.GetComponent<Health>();
            if(collisionObjectHealth == null){
                return;
            }
            collisionObjectHealth.TakeDamage(damage);
        }
    }

    public void SetDamage(float setDamage){
        damage = setDamage;
    }
}
