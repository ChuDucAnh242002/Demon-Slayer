using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 15;
    private float initHealth;
    [SerializeField] private HealthManager healthManager;
    
    // Start is called before the first frame update
    void Start()
    {
        initHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    public void TakeDamage(float damage){
        health -= damage;
        if (healthManager == null) return;
        
        healthManager.SetHealthBar(health, initHealth);
    }

    private void Die(){
        if(health > 0){
            return;
        } else if (health <= 0){
            Destroy(gameObject);
        }
    }
}
