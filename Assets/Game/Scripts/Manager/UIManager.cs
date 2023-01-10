using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private Animator buttonGiggle;

    

    [SerializeField] private InteractScript interactScript;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private LevelManager lvlManager;
    [SerializeField] private PlayerStatus playerStatus;

    [SerializeField] private CanvasGroup playerUI;
    [SerializeField] private CanvasGroup dialogueUI;
    [SerializeField] private CanvasGroup inventoryUI;
    [SerializeField] private CanvasGroup shadowAnaUI;
    [SerializeField] private CanvasGroup pauseUI;

    [SerializeField] private CanvasGroup parch1UI;
    [SerializeField] private CanvasGroup parch2UI;
    [SerializeField] private CanvasGroup pnj1UI;
    [SerializeField] private CanvasGroup pnj2UI;

    [SerializeField] private CanvasGroup menuCanvas;
    [SerializeField] private CanvasGroup languageCanvas;

    [SerializeField] private NavMeshAgent agent;

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Time.timeScale= 1.0f;
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (playerStatus.parchRestored1)
            {
                parch1UI.interactable = true;
                parch1UI.blocksRaycasts = true;
                parch1UI.alpha = 1f;
            }

            if (playerStatus.invGiggled)
            {
                buttonGiggle.SetBool("Start", true);
                playerStatus.invGiggled = false;
            }

            if (playerStatus.parchRestored2)
            {
                parch2UI.interactable = true;
                parch2UI.blocksRaycasts = true;
                parch2UI.alpha = 1f;
            }
            if (playerStatus.talkedPNJ1)
            {
                pnj1UI.interactable = true;
                pnj1UI.blocksRaycasts = true;
                pnj1UI.alpha = 1f;
            }
            if (playerStatus.talkedPNJ2)
            {
                pnj2UI.interactable = true;
                pnj2UI.blocksRaycasts = true;
                pnj2UI.alpha = 1f;
            }
        }
    }

    public void CloseShadowAna()
    {
        interactScript.camShadowAnaObj.SetActive(false);
        interactScript.camPlayerObj.SetActive(true);
        interactScript.inInteraction = false;
        shadowAnaUI.interactable = false;
        shadowAnaUI.blocksRaycasts = false;
        shadowAnaUI.alpha = 0f;
        playerUI.interactable = true;
        playerUI.blocksRaycasts = true;
        playerUI.alpha = 1f;
    }

    public void CloseDialogue()
    {
        dialogueManager.EndDialogue();
    }

    public void OpenInventory()
    {
        FindObjectOfType<InventoryManager>().SelectItem(-1);
        interactScript.inInteraction = true;
        playerUI.interactable = false;
        playerUI.blocksRaycasts = false;
        playerUI.alpha = 0f;
        inventoryUI.interactable = true;
        inventoryUI.blocksRaycasts = true;
        inventoryUI.alpha = 1f;
    }
    public void CloseInventory()
    {
        Debug.Log("Babar");
        interactScript.inInteraction = false;
        playerUI.interactable = true;
        playerUI.blocksRaycasts = true;
        playerUI.alpha = 1f;
        inventoryUI.interactable = false;
        inventoryUI.blocksRaycasts = false;
        inventoryUI.alpha = 0f;
    }

    public void PauseMenu()
    {
        Debug.Log("Patate");
        interactScript.inInteraction = true;
        playerUI.interactable = false;
        playerUI.blocksRaycasts = false;
        playerUI.alpha = 0f;
        pauseUI.interactable = true;
        pauseUI.blocksRaycasts = true;
        pauseUI.alpha = 1f;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        interactScript.inInteraction = false;
        playerUI.interactable = true;
        playerUI.blocksRaycasts= true;
        playerUI.alpha = 1f;
        pauseUI.interactable = false;
        pauseUI.blocksRaycasts = false;
        pauseUI.alpha = 0f;
        Time.timeScale = 1f;
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            agent.isStopped = true;
        }

    }

    public void OpenLanguageCanvas()
    {
        languageCanvas.interactable = true;
        languageCanvas.blocksRaycasts = true;
        languageCanvas.alpha = 1f;
        menuCanvas.interactable = false;
        menuCanvas.blocksRaycasts = false;
        menuCanvas.alpha = 0f;
    }

    public void CloseLanguageCanvas()
    {
        languageCanvas.interactable = false;
        languageCanvas.blocksRaycasts = false;
        languageCanvas.alpha = 0f;
        menuCanvas.interactable = true;
        menuCanvas.blocksRaycasts = true;
        menuCanvas.alpha = 1f;
    }

    public void GoMenu()
    {
        FindObjectOfType<LaunchDialogEvents>().timer = 0f;
        transition.ResetTrigger("Start");
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
