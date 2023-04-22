using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private GameObject player;
    private Rigidbody2D rb;
    private float timer;
    private float damage = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x , direction.y).normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 10f){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")){
            Health collisionObjectHealth = collision.gameObject.GetComponent<Health>();
            if(collisionObjectHealth == null){
                return;
            }
            collisionObjectHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
