using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityFloor_LeverBox_Activator : MonoBehaviour
{
    public GameObject[] Leverbox_Array;
    public int Randombox_Value;

    // Start is called before the first frame update
    void Start()
    {
        Randombox_Value = Random.Range(0, 3);
        Leverbox_Array[0].gameObject.SetActive(false);
        Leverbox_Array[1].gameObject.SetActive(false);
        Leverbox_Array[2].gameObject.SetActive(false);
        Leverbox_Array[3].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Leverbox_Array[Randombox_Value].gameObject.SetActive(true);
    }
}