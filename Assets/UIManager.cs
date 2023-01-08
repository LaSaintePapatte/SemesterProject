using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private InteractScript interactScript;
    [SerializeField] private DialogueManager dialogueManager;

    [SerializeField] private GameObject playerUI;
    [SerializeField] private GameObject dialogueUI;

    public void CloseShadowAna()
    {
        interactScript.camShadowAnaObj.SetActive(false);
        interactScript.camPlayerObj.SetActive(true);
        interactScript.inInteraction = false;
        interactScript.shadowAnaUI.SetActive(false);
        interactScript.playerUI.SetActive(false);
    }

    public void CloseDialogue()
    {
        interactScript.inInteraction = false;
        dialogueUI.SetActive(false);
        playerUI.SetActive(false);
        dialogueManager.EndDialogue();
    }
}
