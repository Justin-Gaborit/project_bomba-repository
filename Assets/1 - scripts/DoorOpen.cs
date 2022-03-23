using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Animator Door_Animator;

    void Start()
    {
        Door_Animator = gameObject.GetComponent<Animator>();
    }

    public void DoorOpensFunction()
    {
        Door_Animator.SetInteger("door_open_condition", 1);
    }

    void Update()
    {
        
    }
}
