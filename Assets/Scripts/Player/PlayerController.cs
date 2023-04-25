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
    [SerializeField] private AudioSource fastSwordSlashSFX;
    [SerializeField] private NPC npc;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        origintalLocalScale = transform.localScale;
        health = GetComponent<Health>();
        breath = GetComponent<Breath>();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        Move(input);
        FlipCharacterSprite(input);
        SetAnimation(input);
        Attack();
        Breathe();
        UseMistGliding();
        QuitGame();
    }

    private void Move(Vector2 input){
        // User don't press Move key
        if(input == Vector2.zero){
            rb.velocity = Vector2.zero;
            return; 
        } 

        rb.velocity = input;
    }

    private void FlipCharacterSprite(Vector2 input){
        if(input.x == 1){
            transform.localScale = origintalLocalScale;
        } else if (input.x == -1){
            Vector3 flipXLocalScale = new Vector3(-origintalLocalScale.x, origintalLocalScale.y, origintalLocalScale.z);
            transform.localScale = flipXLocalScale;
        }
    }

    private void SetAnimation(Vector2 input){
        if((input.x == 1 || input.x == -1) && input.y == 0){
            animator.SetBool("MoveRight", true);
        } else if(input.y == -1 && input.x ==0){
            animator.SetBool("MoveFront", true);
        } else if(input.y == 1 && input.x == 0){
            animator.SetBool("MoveBack", true);
        } else if(input == Vector2.zero){
            ResetAnimation();
        } 
    }

    private void ResetAnimation(){
        animator.SetBool("MoveRight", false);
        animator.SetBool("MoveFront", false);
        animator.SetBool("MoveBack", false);
    }

    private void Attack(){
        if (!Input.GetKey(KeyCode.J)) return;
 
        bool playerIsCloseToNPC = npc.GetPlayerClose();
        if(playerIsCloseToNPC) return;

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
            breath.UseBreathe();
        }
    }

    private void UseMistGliding(){
        if(!Input.GetKey(KeyCode.L)) return;
        if(!breath.isMistGlidingOn()) return;
        animator.SetTrigger("LunarMist");
        dashMistGliding();
    }

    private void dashMistGliding(){
        StartCoroutine(coroutineMistGlding());
    }

    private IEnumerator coroutineMistGlding(){
        rb.velocity = new Vector2(transform.localScale.x * lunarMist.GetLunarMistSpeed(), 0f);
        boxCollider2D.enabled = false;

        yield return new WaitForSeconds(lunarMist.GetLunarMistTime());

        boxCollider2D.enabled = true;
    }

    private void QuitGame(){
        if(Input.GetKey(KeyCode.Escape)){
            SceneManager.LoadScene("MainMenuScene");
        }
    }

}
