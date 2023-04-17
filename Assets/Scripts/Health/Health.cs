using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    public void TakeDamage(int damage){
        health -= damage;
    }

    private void Die(){
        if(health > 0){
            return;
        } else if (health <= 0){
            Destroy(gameObject);
        }
    }
}
