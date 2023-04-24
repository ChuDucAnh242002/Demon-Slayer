using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    private Vector3 origintalLocalScale;
    private Vector2 input;
    public SwordAttack swordAttack;
    private Health health;
    private Breath breath;
    public LunarMist lunarMist;
    private Animator animator;
    private BoxCollider2D boxCollider2D;
    // [SerializeField] private AudioSource slashBeHeadSFX;
    // [SerializeField] private AudioSource grassyWalkSFX;
    [SerializeField] private AudioSource fastSwordSlashSFX;
    // [SerializeField] private AudioSource cobbleWalkSFX;

    [SerializeField] private NPC npc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        origintalLocalScale = transform.localScale;
        health = GetComponent<Health>();
        breath = GetComponent<Breath>();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        Move(input);
        Flip(input);
        SetAnimation(input);
        Attack();
        Breathe();
        UseLunarMist();
        QuitGame();
    }

    private void Move(Vector2 input){

        if(input == Vector2.zero){
            rb.velocity = Vector2.zero;
           return; 
        } 

        if(input != Vector2.zero){
            // grassyWalkSFX.Play();
            rb.velocity = input;
        } 
    }

    // Change character direction when move
    private void Flip(Vector2 input){
        if(input.x == 1){
            transform.localScale = new Vector3(origintalLocalScale.x, origintalLocalScale.y, origintalLocalScale.z);
        } else if (input.x == -1){
            transform.localScale = new Vector3(-origintalLocalScale.x, origintalLocalScale.y, origintalLocalScale.z);
        }
    }

    private void SetAnimation(Vector2 input){
        if(input.x == 1 || input.x == -1){
            animator.SetBool("MoveRight", true);
        } else if(input.y == -1){
            animator.SetBool("MoveFront", true);
        } else if(input.y == 1){
            animator.SetBool("MoveBack", true);
        } else {
            ResetAnimation();
        }
    }

    private void ResetAnimation(){
        animator.SetBool("MoveRight", false);
        animator.SetBool("MoveFront", false);
        animator.SetBool("MoveBack", false);
    }

    private void Attack(){
        if (!Input.GetKey(KeyCode.J)){
            swordAttack.StopAttack();
            return;
        } 
        bool playerIsCloseToNPC = npc.GetPlayerClose();
        if(playerIsCloseToNPC) return;

        swordAttack.Attack();
        animator.SetTrigger("NormalAttack");
        fastSwordSlashSFX.Play();
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

    private void UseLunarMist(){
        if(!Input.GetKey(KeyCode.L)) return;
        if(!breath.isLunarMistOn()) return;
        animator.SetTrigger("LunarMist");
        dashLunarMist();
    }

    private void dashLunarMist(){
        StartCoroutine(coroutineLunarMist());
    }

    private IEnumerator coroutineLunarMist(){
        rb.velocity = new Vector2(transform.localScale.x * lunarMist.GetLunarMistSpeed(), 0f);
        boxCollider2D.enabled = false;

        yield return new WaitForSeconds(lunarMist.GetLunarMistTime());
        yield return new WaitForSeconds(lunarMist.GetLunarMistCooldown());

        boxCollider2D.enabled = true;
    }

    private void QuitGame(){
        if(Input.GetKey(KeyCode.Escape)){
            SceneManager.LoadScene("MainMenuScene");
        }
    }

}
