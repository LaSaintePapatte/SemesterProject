using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
using Unity.VisualScripting;

public class InteractScript : MonoBehaviour
{
    [SerializeField] private Camera camPlayer;
    [SerializeField] private Camera camShadowAna;

    [SerializeField] private PlayerStatus playerStatusScript;

    public GameObject camPlayerObj;
    public GameObject camShadowAnaObj;
    [SerializeField] private GameObject anaGame;
    [SerializeField] private GameObject player;
    public GameObject dialogueUI;
    public GameObject playerUI;
    public GameObject minigameUI;
    public GameObject shadowAnaUI;

    public bool inInteraction = false;

    public void Interact()
    {
        Ray ray = camPlayer.ScreenPointToRay(Touch.activeTouches[0].screenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null && hit.distance < 3)
            {
                if (hit.collider.gameObject.CompareTag("ShadowAna"))
                {
                    if (playerStatusScript.hasParch1 && playerStatusScript.hasCastrum && !playerStatusScript.parchRestored1)
                    {
                        inInteraction = true;
                        anaGame.SetActive(true);
                        camShadowAnaObj.SetActive(true);
                        camPlayerObj.SetActive(false);
                        playerUI.SetActive(false);
                        shadowAnaUI.SetActive(true);
                    }

                }
                if (hit.collider.gameObject.CompareTag("PNJ1"))
                {
                    if (!playerStatusScript.talkedPNJ1)
                    {
                        playerStatusScript.talkedPNJ1 = true;
                    }

                    hit.collider.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                    inInteraction = true;
                    playerUI.SetActive(false);
                    dialogueUI.SetActive(true);

                }
                if (hit.collider.gameObject.CompareTag("PNJ2"))
                {
                    if (playerStatusScript.talkedPNJ1 && playerStatusScript.parchRestored1 && playerStatusScript.parchRestored2)
                    {
                        playerStatusScript.talkedPNJ2 = true;
                        hit.collider.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                        inInteraction = true;
                        playerUI.SetActive(false);
                        dialogueUI.SetActive(true);
                    }
                }
                if (hit.collider.gameObject.CompareTag("Parchment1"))
                {
                    if (!playerStatusScript.hasParch1)
                    {
                        playerStatusScript.hasParch1 = true;
                        GameObject parch1 = GameObject.Find("Parchment1");
                        parch1.SetActive(false);
                    }
                }
                if (hit.collider.gameObject.CompareTag("Parchment2"))
                {
                    if (!playerStatusScript.hasParch2)
                    {
                        playerStatusScript.hasParch2 = true;
                        GameObject parch2 = GameObject.Find("Parchment2");
                        parch2.SetActive(false);

                    }
                }
                if (hit.collider.gameObject.CompareTag("ParchFrag1"))
                {
                    if (!playerStatusScript.hasParchFrag1)
                    {
                        playerStatusScript.hasParchFrag1 = true;
                        GameObject parchFrag1 = GameObject.Find("ParchFrag1");
                        parchFrag1.SetActive(false);

                    }
                }
                if (hit.collider.gameObject.CompareTag("ParchFrag2"))
                {
                    if (!playerStatusScript.hasParchFrag2)
                    {
                        playerStatusScript.hasParchFrag2 = true;
                        GameObject parchFrag2 = GameObject.Find("ParchFrag2");
                        parchFrag2.SetActive(false);

                    }
                }
                if (hit.collider.gameObject.CompareTag("Castrum"))
                {

                    if (!playerStatusScript.hasCastrum)
                    {
                        playerStatusScript.hasCastrum = true;
                        GameObject castrum = GameObject.Find("ShadowAnaObj");
                        castrum.SetActive(false);
                    }
                }
                if (hit.collider.gameObject.CompareTag("Coin"))
                {

                    if (!playerStatusScript.hasCoin)
                    {
                        playerStatusScript.hasCoin = true;
                        player.SetActive(false);
                        playerStatusScript.minigame.SetActive(true);
                        playerUI.SetActive(false);
                        minigameUI.SetActive(true);
                    }
                }
                if (hit.collider.gameObject.CompareTag("House"))
                {
                    Debug.Log("Babar");
                    playerUI.SetActive(false);
                    minigameUI.SetActive(true);
                    player.SetActive(false);
                    playerStatusScript.minigame.SetActive(true);
                    
                }
            }
        }
    }
}