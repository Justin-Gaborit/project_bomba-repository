using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomNoteUIManager : MonoBehaviour
{
    private bool Note_Open;

    [Header("Note 1")]
    [SerializeField] private UnityEvent OpenNote_1 = null;
    [SerializeField] private UnityEvent CloseNote_1 = null;

    void Start()
    {
        Note_Open = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OpenNote_1.Invoke();
            Note_Open = true;
        }

        if (Input.GetKeyUp(KeyCode.Alpha1) && Note_Open == true)
        {
            CloseNote_1.Invoke();
            Note_Open = false;
        }
    }
}
