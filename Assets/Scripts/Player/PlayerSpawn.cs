using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public Vector3 respawnPosition;
    private Health health;
    [SerializeField] private FadeScene fadeScene;

    private void Start(){
        health = GetComponent<Health>();
    }

    private void Update(){
        Respawn();
    }

    private void Respawn(){
        
        if(!health.IsDead()) return;
        print("respawn");
        transform.localPosition = respawnPosition;

        health.ResetHealth();
        Fade();
    }

    private void Fade(){
        fadeScene.FadeOut();
        fadeScene.FadeIn();
    }

}
