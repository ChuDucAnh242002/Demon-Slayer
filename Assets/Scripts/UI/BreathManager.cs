using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreathManager : MonoBehaviour
{
    [SerializeField] private Image breathBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBreathBar(float breath, float initBreath){
        float breathScale = breath / initBreath;
        breathBar.transform.localScale = new Vector3(breathScale, 1f, 0f);
    }
}
