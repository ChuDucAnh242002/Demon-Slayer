using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float chaseDistance = 5f;
    private Transform playerTransform;
    private Transform AITransform;
    private Rigidbody2D AIrb;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        AITransform = GetComponent<Transform>();
        AIrb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
    }

    void Chase(){
        if (playerTransform == null) return;

        float distanceToTarget = Vector2.Distance(AITransform.position, playerTransform.position);

        // Only chase when in the circle which radius is chase Distance
        if(distanceToTarget > chaseDistance){
            return;
        }

        Vector2 direction = new Vector2(playerTransform.position.x - AITransform.position.x, playerTransform.position.y - AITransform.position.y);
        AIrb.velocity = direction * speed;
    }
}
