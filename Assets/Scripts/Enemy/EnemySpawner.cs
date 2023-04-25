using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject winWindow;

    private void Update(){
        SetWin();
    }

    private void SetWin(){
        if(transform.childCount > 0) return;
        winWindow.SetActive(true);
    }

    public void ReturnMainMenu(){
        SceneManager.LoadScene("MainMenuScene");
    }
}
