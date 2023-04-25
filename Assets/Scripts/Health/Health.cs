using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 15;
    private float initHealth;
    [SerializeField] private HealthManager healthManager;
    private Animator animator;
    public float dieAnimationTime = 1f;
    [SerializeField] private AudioSource slashBeHeadSFX;
    // private BoxCollider2D boxCollider2D;
    
    // Start is called before the first frame update
    void Start()
    {
        initHealth = health;
        animator = GetComponent<Animator>();
        // boxCollider2D = GetComponent<BoxCollider2D>();
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
        if(health > 0) return;
        if(transform.gameObject.tag == "Player") return;
        slashBeHeadSFX.Play();
        StartCoroutine(CoroutineDie());
        
    }

    private IEnumerator CoroutineDie(){
        animator.SetTrigger("Die");
        // boxCollider2D.enabled = false;
        yield return new WaitForSeconds(dieAnimationTime);

        Destroy(gameObject);
    }

    public bool IsDead(){
        if(health > 0) return false;
        return true;
    }

    public void ResetHealth(){
        health = initHealth;
        healthManager.SetHealthBar(health, initHealth);
    }
}
