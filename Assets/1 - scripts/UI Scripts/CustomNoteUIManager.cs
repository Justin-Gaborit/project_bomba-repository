using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomNoteUIManager : MonoBehaviour
{
    private bool Note_1_Open;

    [Header("Open Note 1")]
    [SerializeField] private UnityEvent OpenNote = null;

    [Header("Close Note 1")]
    [SerializeField] private UnityEvent CloseNote = null;

    void Start()
    {
        Note_1_Open = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OpenNote.Invoke();
            Note_1_Open = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && Note_1_Open == true)
        {
            CloseNote.Invoke();
            Note_1_Open = false;
        }
    }
}
