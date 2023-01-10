using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalizedBusyDialogue : MonoBehaviour
{
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            TextMeshProUGUI Text = GetComponent<TextMeshProUGUI>();//get component
            DialogueTriggerOccupied dialogueTrigger = GetComponent<DialogueTriggerOccupied>();
            Dialogue dialogue = dialogueTrigger.dialogue;
            for (int i = 0; i < dialogue.sentences.Length; i++)
            {
                string temp = LocalizationSystem.instance.GetLocalizedValue(dialogue.sentences[i]);
                if (!string.IsNullOrEmpty(temp))
                {
                    temp = temp.Replace('@', '\n');
                    dialogue.sentences[i] = temp;
                }
                else//invalid
                {
                    //Text.color = Color.red;
                    //dialogue.sentences[i] = Color.red;
                    Debug.LogError("NO VALUE FOR KEY: " + dialogue.sentences[i]);
                    //keep the placeholder text in the TMP-UGUI

                }
            }
        }
    }
}
