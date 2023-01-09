using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class LocalizedDialogue : MonoBehaviour
{
    void Start()
    {
        TextMeshProUGUI Text = GetComponent<TextMeshProUGUI>();//get component
        DialogueTrigger dialogueTrigger = GetComponent<DialogueTrigger>();
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
        dialogueTrigger.dialogue = dialogue; //updates text
    }

}
