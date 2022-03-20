using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hall_Segment_3_Generation : MonoBehaviour
{
    public GameObject[] RoomArray;
    public GameObject RoomSpawnLocation;
    //public GameObject[] ManagerArray;
    public int RandomValue;

    public GameObject Level_Manager;
    public int Room_Step;

    void Start()
    {
        RoomArray[0] = Resources.Load("bunker_power_room_obj") as GameObject;
        RoomArray[1] = Resources.Load("bunker_barraks_room_obj") as GameObject;
        RoomArray[2] = Resources.Load("bunker_room3_room_obj") as GameObject;
        RoomArray[3] = Resources.Load("bunker_control_room_obj") as GameObject;

        Level_Manager = GameObject.Find("Level_Manager_Object");
        //Room_Step = GameObject.Find("Level_Manager_Object").GetComponent<RoomGenerationManager>().Current_Room_Spawn_Step;


        Vector3 SpawnLocation = new Vector3();
        SpawnLocation = RoomSpawnLocation.transform.position;
        RandomValue = Random.Range(0, 3);
        //Instantiate(RoomArray[RandomValue], SpawnLocation, RoomSpawnLocation.transform.rotation);
        Level_Manager.GetComponent<RoomGenerationManager>().Current_Room_Spawn_Step -= 1;
        //Destroy(gameObject);

        //Get Ahold of Level Manager Array
        //ManagerArray = GameObject.Find("Level_Manager_Object").GetComponent<RoomGenerationManager>().RoomSpawnPointList;

        Debug.Log("room instantiated");
    }

    void Update()
    {

    }
}
