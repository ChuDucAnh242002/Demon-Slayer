using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private PlayerSpawn playerSpawn;

    // Change player's respawn position to current spawn point
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            Vector3 playerRespawnPosition = playerSpawn.respawnPosition; 
            playerRespawnPosition = transform.localPosition;
        }
    }
}
