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
    private Vector3 SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        origintalLocalScale = transform.localScale;
        health = GetComponent<Health>();
        breath = GetComponent<Breath>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        Move(input);
        Flip(input);
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

    private void UseLunarMist(){
        if(!Input.GetKey(KeyCode.L)) return;
        if(!breath.isLunarMistOn()) return;
        dashLunarMist();
    }

    private void dashLunarMist(){
        StartCoroutine(coroutineLunarMist());
    }

    private IEnumerator coroutineLunarMist(){
        rb.velocity = new Vector2(transform.localScale.x * lunarMist.GetLunarMistSpeed(), 0f);
        yield return new WaitForSeconds(lunarMist.GetLunarMistTime());
        yield return new WaitForSeconds(lunarMist.GetLunarMistCooldown());
    }

    private void QuitGame(){
        if(Input.GetKey(KeyCode.Escape)){
            SceneManager.LoadScene("MainMenuScene");
        }
    }

}
