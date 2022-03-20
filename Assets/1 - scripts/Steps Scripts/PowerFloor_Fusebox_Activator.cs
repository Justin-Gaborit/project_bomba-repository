using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerFloor_Fusebox_Activator : MonoBehaviour
{
    public GameObject[] FuseBoxes;
    public GameObject[] FuseGroups;
    int FuseBox_Value;
    int FuseGroup_Value;

    // Start is called before the first frame update
    void Start()
    {
        FuseBox_Value = Random.Range(0,4);
        FuseGroup_Value = Random.Range(0, 3);

        FuseBoxes[0].gameObject.SetActive(false);
        FuseBoxes[1].gameObject.SetActive(false);
        FuseBoxes[2].gameObject.SetActive(false);
        FuseBoxes[3].gameObject.SetActive(false);
        FuseBoxes[4].gameObject.SetActive(false);

        FuseGroups[0].gameObject.SetActive(false);
        FuseGroups[1].gameObject.SetActive(false);
        FuseGroups[2].gameObject.SetActive(false);
        FuseGroups[3].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        FuseBoxes[FuseBox_Value].SetActive(true);
        FuseGroups[FuseGroup_Value].SetActive(true);
    }
}
