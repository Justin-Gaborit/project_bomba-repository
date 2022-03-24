using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadBlocker : MonoBehaviour
{
    public GameObject Keypad_Blocker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DisableKeypadBlocker()
    {
        Keypad_Blocker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
