using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hall_Segment_1_Generation : MonoBehaviour
{
    public GameObject[] HallArray;
    public GameObject HallSpawnLocation;
    public int RandomValue;

    void Start()
    {
        HallArray[0] = Resources.Load("bunker_hallway_straight_1_obj") as GameObject;
        HallArray[1] = Resources.Load("bunker_hallway_straight_2_obj") as GameObject;
        HallArray[2] = Resources.Load("bunker_hallway_straight_3_obj") as GameObject;
        HallArray[3] = Resources.Load("bunker_hallway_straight_1_obj") as GameObject;
        HallArray[4] = Resources.Load("bunker_hallway_straight_2_obj") as GameObject;
        HallArray[5] = Resources.Load("bunker_hallway_straight_3_obj") as GameObject;
        HallArray[6] = Resources.Load("bunker_hallway_straight_1_obj") as GameObject;
        HallArray[7] = Resources.Load("bunker_hallway_straight_2_obj") as GameObject;
        HallArray[8] = Resources.Load("bunker_hallway_straight_3_obj") as GameObject;

        Vector3 SpawnLocation = new Vector3();
        SpawnLocation = HallSpawnLocation.transform.position;
        RandomValue = Random.Range(0, 9);
        Instantiate(HallArray[RandomValue], SpawnLocation, HallSpawnLocation.transform.localRotation);
        //Destroy(gameObject);

        Debug.Log("wall instantiated");
    }


}
