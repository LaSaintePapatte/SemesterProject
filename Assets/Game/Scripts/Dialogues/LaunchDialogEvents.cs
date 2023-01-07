using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class LaunchDialogEvents : MonoBehaviour
{
    [SerializeField]
    List<UnityEvent> Events = new List<UnityEvent>();







    // Start is called before the first frame update
    void Start()
    {
        Events[0].Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
