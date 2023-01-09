using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LaunchDialogEvents : MonoBehaviour
{
    [SerializeField]
    List<UnityEvent> events = new List<UnityEvent>();

    [SerializeField] private PlayerStatus playerStatus;

    private bool dialog1Done = false;
    private bool dialog2Done = false;
    private bool dialog3Done = false;
    private bool dialog4Done = false;
    private bool dialog5Done = false;
    private bool dialog6Done = false;
    private bool dialog7Done = false;
    private bool dialog8Done = false;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(timer);
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            timer += Time.deltaTime;
            if (timer > 10f && !dialog1Done)
            {
                events[0].Invoke();
                dialog1Done = true;
            }

            if (timer > 30f && !dialog2Done)
            {
                events[1].Invoke();
                dialog2Done = true;
            }
            if (playerStatus.inHouse && !dialog3Done && dialog2Done)
            {

                events[2].Invoke();
                dialog3Done = true;
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            timer += Time.deltaTime;

            if (timer > 10f && !dialog1Done)
            {
                Debug.Log("1");
                events[0].Invoke();
                dialog1Done = true;
            }

            if (playerStatus.hasParch2 && !dialog2Done)
            {
                Debug.Log("2");
                events[1].Invoke();
                dialog2Done = true;
            }
            if (playerStatus.hasParch1 && !dialog4Done)
            {
                Debug.Log("4");
                events[3].Invoke();
                dialog4Done = true;
            }
            if (playerStatus.parchRestored1 && !dialog5Done)
            {
                Debug.Log("5");
                events[4].Invoke();
                dialog5Done = true;
            }
            if (playerStatus.talkedPNJ1 && !dialog6Done && !FindObjectOfType<InteractScript>().inInteraction)
            {
                Debug.Log("6");
                events[5].Invoke();
                dialog6Done = true;
            }
            if (playerStatus.talkedPNJ2 && !dialog7Done && !FindObjectOfType<InteractScript>().inInteraction)
            {
                Debug.Log("7");
                events[6].Invoke();
                dialog7Done = true;
            }
            if (playerStatus.nearGroup && !dialog8Done)
            {
                Debug.Log("8");
                events[7].Invoke();
                dialog8Done = true;
            }

        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            timer += Time.deltaTime;

            //if (dialog1Done && !dialog2Done)
            //{
            //    timer += Time.deltaTime;
            //}
            

            if (timer > 10f && !dialog1Done)
            {
                Debug.Log("1");
                events[0].Invoke();
                dialog1Done = true;
            }

            if (timer > 25f && !dialog2Done)
            {
                events[1].Invoke();
                dialog2Done = true;
                timer = 0f;
            }
        }
    }
}
