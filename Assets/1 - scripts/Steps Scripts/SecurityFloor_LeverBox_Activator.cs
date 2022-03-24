using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityFloor_LeverBox_Activator : MonoBehaviour
{
    public GameObject[] LeverBoxes;
    public GameObject[] LeverGroups;

    int LeverBox_Value;
    int LeverGroup_Value;

    // Start is called before the first frame update
    void Start()
    {
        LeverBox_Value = Random.Range(0, 3);
        LeverGroup_Value = Random.Range(0, 3);

        LeverBoxes[0].gameObject.SetActive(false);
        LeverBoxes[1].gameObject.SetActive(false);
        LeverBoxes[2].gameObject.SetActive(false);
        LeverBoxes[3].gameObject.SetActive(false);
        LeverBoxes[4].gameObject.SetActive(false);

        LeverGroups[0].gameObject.SetActive(false);
        LeverGroups[1].gameObject.SetActive(false);
        LeverGroups[2].gameObject.SetActive(false);
        LeverGroups[3].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        LeverBoxes[LeverBox_Value].SetActive(true);
        LeverGroups[LeverGroup_Value].SetActive(true);
    }
}