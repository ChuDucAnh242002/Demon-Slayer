using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public Vector3 respawnPosition;
    private Health health;
    private Animator animator;
    [SerializeField] private FadeScene fadeScene;

    private void Start(){
        health = GetComponent<Health>();
        animator = GetComponent<Animator>();
    }

    private void Update(){
        Respawn();
    }

    private void Respawn(){
        
        if(!health.IsDead()) return;
        // StartCoroutine(CoroutineRespawn());
        transform.localPosition = respawnPosition;
        health.ResetHealth();
        Fade();
        
    }

    private IEnumerator CoroutineRespawn(){
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(health.dieAnimationTime * 2);
        
        yield return null;
    }

    private void Fade(){
        fadeScene.FadeOut();
        fadeScene.FadeIn();
    }

}
