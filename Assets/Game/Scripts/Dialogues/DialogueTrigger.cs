using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    [SerializeField] private PlayerStatus playerStatus;

    //public TextMeshProUGUI nameText;
    //public TextMeshProUGUI dialogueText;

    //public Animator animator;

    //private Queue<string> sentences;

    // Start is called before the first frame update
    //void Start()
    //{
    //    sentences = new Queue<string>();
    //}

    //private void Update()
    //{
    //    if (playerStatus.talkingPNJ1 && playerStatus.talkedPNJ1)
    //    {
    //        TriggerDialogue();
    //        playerStatus.talkingPNJ1 = false;
    //    }
    //    if (playerStatus.talkingPNJ2 && playerStatus.talkedPNJ2)
    //    {
    //        TriggerDialogue();
    //        playerStatus.talkingPNJ2 = false;
    //    }
    //}

    public void TriggerDialogue ()
    {
        Debug.Log("patateuh");


        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        //StartDialogue(dialogue);
    }

    //public void StartDialogue(Dialogue dialogue)
    //{
    //    animator.SetBool("IsOpen", true);

    //    nameText.text = dialogue.name;

    //    sentences.Clear();

    //    foreach (string sentence in dialogue.sentences)
    //    {
    //        sentences.Enqueue(sentence);
    //    }

    //    DisplayNextSentence();
    //}

    //public void DisplayNextSentence()
    //{
    //    if (sentences.Count == 0)
    //    {
    //        EndDialogue();
    //        return;
    //    }

    //    string sentence = sentences.Dequeue();
    //    //dialogueText.text = sentence;

    //    StopAllCoroutines();
    //    StartCoroutine(TypeSentence(sentence));
    //}

    //IEnumerator TypeSentence (string sentence)
    //{
    //    dialogueText.text = "";
    //    foreach(char letter in sentence.ToCharArray())
    //    {
    //        dialogueText.text += letter;
    //        yield return null;
    //    }
    //}

    //void EndDialogue()
    //{
    //    animator.SetBool("IsOpen", false);
        
    //}
}

