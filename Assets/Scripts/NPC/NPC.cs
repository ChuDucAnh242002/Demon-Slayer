using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private string[] dialogue;
    [SerializeField] private float wordSpeed;
    private int index = 0;
    private bool playerIsClose;


    // Update is called once per frame
    void Update()
    {
        TalkWithNPC();
        
    }

    private void TalkWithNPC(){
        if(!Input.GetKeyDown(KeyCode.J)) return;
        if(!playerIsClose) return;
        // print("yest");
        if(dialogueText.text == ""){
            dialoguePanel.SetActive(true);
            StartCoroutine(Typing());
            return;
        } else if(dialogueText.text != dialogue[index]) {
            StopAllCoroutines();
            dialogueText.text = dialogue[index];
            return;
        } else {
            NextLine();
        }
        
    }


    public void zeroText(){
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing(){
        foreach(char letter in dialogue[index].ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(1/wordSpeed);
        }
    }

    public void NextLine(){
        if(index < dialogue.Length - 1){
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        } else {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Player")){
            playerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider){
        if (collider.CompareTag("Player")){
            playerIsClose = false;
            StopAllCoroutines();
            zeroText();
        }
    }
}
