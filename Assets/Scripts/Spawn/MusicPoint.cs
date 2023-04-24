using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPoint : MonoBehaviour
{
    // private bool isPlayerPass = false;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private AudioSource villageScore;
    [SerializeField] private AudioSource combatScoreFast;

    private void Start(){
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // private void OnTriggerEnter2D(Collider2D collision){
    //     if(collision.CompareTag("Player")){
            
    //     }
    // }

    private void OnTriggerExit2D(Collider2D collsion){
        if(collsion.CompareTag("Player")){
            boxCollider2D.isTrigger = false;
            villageScore.Stop();
            combatScoreFast.Play();
        }
    }

    // public bool GetPlayerPass(){
    //     return isPlayerPass;
    // }
}
