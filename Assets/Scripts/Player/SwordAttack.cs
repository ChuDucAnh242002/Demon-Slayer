using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField] private float damage = 5;

    // Sword collider hit enemy and deal damange
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Enemy"){
            Health collisionObjectHealth = collision.gameObject.GetComponent<Health>();
            if(collisionObjectHealth == null) return;
            collisionObjectHealth.TakeDamage(damage);
        }
    }

    public void SetDamage(float setDamage){
        damage = setDamage;
    }
}
