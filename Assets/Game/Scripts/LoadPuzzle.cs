using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPuzzle : MonoBehaviour
{

    public GameObject puzzle;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            if (puzzle.activeInHierarchy)
            {
                puzzle.SetActive(false);
            }
            else
            {
                puzzle.SetActive(true);
            }
        }
    }
}
