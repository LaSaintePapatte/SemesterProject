using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parchment1Script : MonoBehaviour
{

    //private bool fragVanish1 = false;
    //private bool fragVanish2 = false;

    Color FragColor;

    public MeshRenderer object1Renderer;
    public MeshRenderer object2Renderer;

    public GameObject player;
    PlayerStatus playerScript;

    // Start is called before the first frame update
    void Start()
    {
        FragColor = object1Renderer.material.color;
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerStatus>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.parchRestored1)
        {
            FragColor.a = Mathf.Lerp(FragColor.a, 0.0f, 0.005f);

            object1Renderer.material.color = FragColor;
            object2Renderer.material.color = FragColor;
        }
    }

    
}
