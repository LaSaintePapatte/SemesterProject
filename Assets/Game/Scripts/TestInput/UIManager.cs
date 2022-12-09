using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{

    private PlayerInput playerInput;
    private PlayerControls playerControls;

    public GameObject player;

    private PlayerController playerControllerScript;

    private Vector2 touchInput = Vector2.zero; 

    public TextMeshProUGUI testText;
    // Start is called before the first frame update
    void Start()
    {
        
        playerControllerScript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        touchInput = playerControllerScript.touchVector;
        
        testText.SetText("TouchPos : " + touchInput);


    }
}
