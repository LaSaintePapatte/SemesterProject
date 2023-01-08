using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    [SerializeField] private InteractScript interactScript;

    private Queue<string> sentences;

    //public static DialogueManager instance;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    [SerializeField] private CanvasGroup playerUI;
    [SerializeField] private CanvasGroup dialogueUI;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

        //instance = this;
    }


    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        //dialogueText.text = sentence;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        playerUI.interactable = true;
        playerUI.blocksRaycasts = true;
        playerUI.alpha = 1f;
        dialogueUI.interactable = false;
        dialogueUI.blocksRaycasts = false;
        dialogueUI.alpha = 0f;
        interactScript.inInteraction = false;
        animator.SetBool("IsOpen", false);
    }
}
