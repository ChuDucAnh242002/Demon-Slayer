using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletPos;
    [SerializeField] private float timeInterval;
    [SerializeField] private float shootDistance;

    private float timer = 0f;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(!ableToShoot()) return;
        timer += Time.deltaTime;
        if(timer > timeInterval){
            timer = 0;
            Shoot();
        }
    }

    private bool ableToShoot(){
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if(distance < shootDistance) return false;
        return true;
    }

    private void Shoot(){
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
