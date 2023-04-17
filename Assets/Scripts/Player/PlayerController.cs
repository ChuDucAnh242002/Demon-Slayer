using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 input;
    public SwordAttack swordAttack;
    public FaceDirection faceDirection;
    private Health health;
    private Breath breath;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        breath = GetComponent<Breath>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        Move(input);
        Attack();
        swordAttack.ChangeSwordDirection(input);
        Breathe();
        Interact();
        faceDirection.ChangeFaceDirection(input);
    }

    private void Move(Vector2 input){

        if(input == Vector2.zero){
            rb.velocity = Vector2.zero;
           return; 
        } 

        if(input != Vector2.zero){
            rb.velocity = input;
        } 
    }

    private void Attack(){
        if (!Input.GetKey(KeyCode.J)){
            swordAttack.StopAttack();
            return;
        } else if (Input.GetKey(KeyCode.J)) {
            swordAttack.Attack();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Enemy"){
            health.TakeDamage(5);
        }
    }

    private void Breathe(){
        if (!Input.GetKey(KeyCode.K)){
            breath.RegenerateBreathe();
            return;
        } 
        else if (Input.GetKey(KeyCode.K)){
            breath.useBreathe();
        }
    }

    private void Interact(){
        faceDirection.CheckFront();
    }
}
