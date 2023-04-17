using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(){
        boxCollider2D.enabled = true;
    }

    public void StopAttack(){
        boxCollider2D.enabled = false;
    }

    public void ChangeSwordDirection(Vector2 input){
        if(input.x == 1){
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else if (input.x == -1){
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    
}
