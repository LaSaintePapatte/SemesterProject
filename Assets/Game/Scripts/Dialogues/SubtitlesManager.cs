using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class SubtitlesManager : MonoBehaviour
{
    private Queue<string> sentences;

    public TextMeshProUGUI dialogueText;

    [SerializeField] private CanvasGroup subtitlesUI;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

        //instance = this;
    }
    public void StartSubtitles(Dialogue dialogue)
    {
        subtitlesUI.interactable = true;
        subtitlesUI.blocksRaycasts = true;
        subtitlesUI.alpha = 1f;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSubtitles();
    }
    public void DisplayNextSubtitles()
    {
        if (sentences.Count == 0)
        {
            EndSubtitles();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;


    }

    public void EndSubtitles()
    {
        subtitlesUI.interactable = false;
        subtitlesUI.blocksRaycasts = false;
        subtitlesUI.alpha = 0f;
    }

}
