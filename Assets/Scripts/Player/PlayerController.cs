using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private LayerMask collisionObjectLayer;
    // private bool isMoving = false;
    private Vector2 input;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    

    private void Start(){
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update(){
        GetInput();
    }

    // private void Move(){
    //     if (!isMoving){
    //         input.x = Input.GetAxisRaw("Horizontal");
    //         input.y = Input.GetAxisRaw("Vertical");

            

    //         if(input != Vector2.zero){
    //             var targetPos = transform.position;
    //             targetPos.x += input.x;
    //             targetPos.y += input.y;
                
    //             StartCoroutine(MoveRoutine(targetPos));
                
    //         }
    //     }

    //     animator.SetBool("isMoving", true);
    // }

    // IEnumerator MoveRoutine(Vector3 targetPos){
    //     isMoving = true;

    //     while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon){
    //         transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    //         yield return null;
    //     }

    //     transform.position = targetPos;
    //     isMoving = false;
    // }

    private void GetInput(){
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        
        Move(input);
        SetMoveAnimation(input);
        SetFlipX(input);


    }

    private void Move(Vector2 input){
        if(input != Vector2.zero){
            var targetPos = transform.position;
            targetPos.x += input.x;
            targetPos.y += input.y;
            if (isWalkable(targetPos)){

                transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime); 
            }
        } 
    }

    private void SetMoveAnimation(Vector2 input){
        if (input != Vector2.zero){
            animator.SetBool("isMoving", true);
        } else {
            animator.SetBool("isMoving", false);
        }
    }

    private void SetFlipX(Vector2 input){
        if(input.x == -1){
            spriteRenderer.flipX = true;
        } else if (input.x == 1){
            spriteRenderer.flipX = false;
        }
    }

    private bool isWalkable(Vector3 targetPos){
        if(Physics2D.OverlapCircle(targetPos, 0.2f, collisionObjectLayer) != null){
            return false;
        }
        return true;
    }
}
