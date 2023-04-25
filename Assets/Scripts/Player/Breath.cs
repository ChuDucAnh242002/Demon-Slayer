using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breath : MonoBehaviour
{
    [SerializeField] private float breatheAmount;
    [SerializeField] private float useBreathAmount;
    [SerializeField] private float regenerateBreatheAmount;
    [SerializeField] private UIManager breathManager;
    [SerializeField] private float powerUp1Time;
    [SerializeField] private float powerUp3Time;

    public SwordAttack swordAttack;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private float originalBreath;
    private float totalUseBreathAmount = 0;
    private float totalTime = 0;
    
    
    private bool mistGlidingOn = false;

    private Color POWERUPCOLOR1 = new Color(1, 0.72f, 0.72f);
    private Color POWERUPCOLOR3 = new Color(1, 0.6f, 0.6f);

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        originalBreath = breatheAmount;
    }

    public void UseBreathe(){
        if(breatheAmount <= 0) return;
        breatheAmount -= useBreathAmount * Time.deltaTime;
        
        breathManager.SetUIBar(breatheAmount, originalBreath);
        totalUseBreathAmount += useBreathAmount * Time.deltaTime;
        if(totalUseBreathAmount >= originalBreath / 5  - 0.1f && totalUseBreathAmount < originalBreath * 2/5){
            PowerUpBreath1();
        }
        if(totalUseBreathAmount >= originalBreath*3/5 - 0.1f && totalUseBreathAmount < originalBreath * 4/5){
            PowerUpBreath3();
        }
        totalTime = 0;
    }

    public void RegenerateBreathe(){
        if(breatheAmount >= originalBreath) return;

        breatheAmount += regenerateBreatheAmount * Time.deltaTime;
        breathManager.SetUIBar(breatheAmount, originalBreath);

        totalUseBreathAmount = 0;
        totalTime += Time.deltaTime;
        if((totalTime >= powerUp1Time && totalTime <= powerUp1Time + 0.05f && !mistGlidingOn) || 
            (totalTime >= powerUp3Time && totalTime <= powerUp3Time + 0.05f && mistGlidingOn)){
            PowerDown();
        } 
    }

    private void PowerUpBreath1(){
        swordAttack.SetDamage(7);
        spriteRenderer.color = POWERUPCOLOR1;
    }

    private void PowerUpBreath3(){
        mistGlidingOn = true;
        spriteRenderer.color = POWERUPCOLOR3 ;
        boxCollider2D.enabled = false;
    }

    public bool isMistGlidingOn(){ return mistGlidingOn;}

    private void PowerDown(){
        swordAttack.SetDamage(5);
        mistGlidingOn = false;
        spriteRenderer.color = Color.white;
        totalTime = 0;
        boxCollider2D.enabled = true;
    }

}
