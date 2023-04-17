using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breath : MonoBehaviour
{
    [SerializeField] private float breatheAmount;
    [SerializeField] private float useBreathAmount;
    [SerializeField] private float regenerateBreatheAmount;
    [SerializeField] private BreathManager breathManager;
    public SwordAttack swordAttack;
    private SpriteRenderer spriteRenderer;
    private float initBreath;
    private float totalUseBreathAmount;
    private float totalTime;
    private Color white = new Color(255, 255, 255);
    private Color red = new Color(229, 34, 34);

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initBreath = breatheAmount;
        totalUseBreathAmount = 0;
        totalTime = 0;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void useBreathe(){
        if(breatheAmount <= 0) return;
        breatheAmount -= useBreathAmount * Time.deltaTime;
        
        breathManager.SetBreathBar(breatheAmount, initBreath);
        totalUseBreathAmount += useBreathAmount * Time.deltaTime;
        if(totalUseBreathAmount >= initBreath / 5  - 0.1f){
            PowerUpBreath1();
        }
        totalTime = 0;
    }

    public void RegenerateBreathe(){
        if(breatheAmount >= initBreath){
            // breatheAmount = initBreath;
            
            return;
        }
        breatheAmount += regenerateBreatheAmount * Time.deltaTime;
        breathManager.SetBreathBar(breatheAmount, initBreath);

        totalUseBreathAmount = 0;
        totalTime += Time.deltaTime;
        if(totalTime >= 2f && totalTime <= 2.05f){
            PowerDown();
        }
    }

    private void PowerUpBreath1(){
        swordAttack.SetDamage(7);
        spriteRenderer.color = Color.red;
    }

    private void PowerDown(){
        swordAttack.SetDamage(5);
        spriteRenderer.color = white;
        totalTime = 0;
    }

}
