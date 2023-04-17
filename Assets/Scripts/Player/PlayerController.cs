using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 input;
    public SwordAttack swordAttack;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        Move(input);
        Attack();
        swordAttack.ChangeSwordDirection(input);
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

    
}
