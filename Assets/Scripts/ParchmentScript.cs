using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParchmentScript : MonoBehaviour
{

    public Material MatFrag1;
    public Material MatFrag2;

    private bool FragVanish1 = false;
    private bool FragVanish2 = false;

    Color Frag1Color;
    Color Frag2Color;

    // Start is called before the first frame update
    void Start()
    {
        Color Frag1Color = MatFrag1.color;
        Color Frag2Color = MatFrag2.color;
    }

    // Update is called once per frame
    void Update()
    {
        Frag1Color.a = Mathf.Lerp(Frag1Color.a, 0, 0.5f);
        Frag2Color.a = Mathf.Lerp(Frag2Color.a, 0.5f, 0.1f);

        MatFrag1.color = Frag1Color;
        MatFrag2.color = Frag2Color;
    } 
}
