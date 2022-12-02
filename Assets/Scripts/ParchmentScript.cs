using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParchmentScript : MonoBehaviour
{

    public Material matFrag1;
    public Material matFrag2;

    private bool fragVanish1 = false;
    private bool FragVanish2 = false;

    Color Frag1Color;
    Color Frag2Color;

    public MeshRenderer object1Renderer;
    public MeshRenderer object2Renderer;

    // Start is called before the first frame update
    void Start()
    {
        Frag1Color = object1Renderer.material.color;

        Frag2Color = object2Renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        Frag1Color.a = Mathf.Lerp(Frag1Color.a, 0.0f, 0.01f);
        Frag2Color.a = Mathf.Lerp(Frag2Color.a, 0.0f, 0.01f);

        object1Renderer.material.color = Frag1Color;
        object2Renderer.material.color = Frag2Color;
    } 
}
