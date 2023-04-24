using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    public void SetHealthBar(float health, float initHealth){
        float healthScale = health / initHealth;
        healthBar.transform.localScale = new Vector3(healthScale, 1f, 0f);
    }
}
