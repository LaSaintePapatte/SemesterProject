using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    [SerializeField] private PlayerStatus playerStatus;

    public void TriggerDialogue ()
    {
        Debug.Log("patateuh");


        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}

