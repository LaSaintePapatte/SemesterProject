using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    [SerializeField] private PlayerStatus playerStatus;

    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void TriggerSubtitles()
    {
        Debug.Log("patateuh");


        FindObjectOfType<SubtitlesManager>().StartSubtitles(dialogue);
    }
}

