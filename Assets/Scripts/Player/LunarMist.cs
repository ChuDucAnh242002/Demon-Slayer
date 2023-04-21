using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunarMist : MonoBehaviour
{
    [SerializeField] private float lunarMistSpeed = 24f;
    [SerializeField] private float lunarMistTime = 0.2f;
    [SerializeField] private float lunarMistCooldown = 1f;
    [SerializeField] private float lunarMistDamage = 50f;
    [SerializeField] private Breath breath;


    public float GetLunarMistSpeed(){return lunarMistSpeed;}
    public float GetLunarMistTime(){return lunarMistTime;}
    public float GetLunarMistCooldown(){return lunarMistCooldown;}
    public float GetLunarMistDamage(){return lunarMistDamage;}

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Enemy" && breath.isLunarMistOn()){
            Health collisionObjectHealth = collision.gameObject.GetComponent<Health>();
            if(collisionObjectHealth == null){
                return;
            }
            collisionObjectHealth.TakeDamage(lunarMistDamage);
        }
    }

}
