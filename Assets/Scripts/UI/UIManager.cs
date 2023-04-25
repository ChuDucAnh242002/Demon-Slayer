using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image uiBar;

    public void SetUIBar(float currentAmount, float originalAmount){
        float barScale = currentAmount/originalAmount;
        uiBar.transform.localScale = new Vector3(barScale, 1f, 0f);
    }
}
