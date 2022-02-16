using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerationManager : MonoBehaviour
{
    public GameObject[] RoomSpawnPointList;
    public int Current_Room_Spawn_Step;

    //Room Spawn Objects
    public GameObject RoomSpawn1;
    public GameObject RoomSpawn2;
    public GameObject RoomSpawn3;
    public GameObject RoomSpawn4;

    //Room GameObjects
    public GameObject RoomObj_1;
    public GameObject RoomObj_2;
    public GameObject RoomObj_3;
    public GameObject RoomObj_4;

    //Room Array
    public GameObject[] RoomArray;

    public int RandomValue1;
    public int RandomValue2;
    public int RandomValue3;





    void Start()
    {
        Current_Room_Spawn_Step = 4;
        RoomObj_1 = Resources.Load("bunker_control_room_obj") as GameObject;
        RoomObj_2 = Resources.Load("bunker_room3_room_obj") as GameObject;
        RoomObj_3 = Resources.Load("bunker_barraks_room_obj") as GameObject;
        RoomObj_4 = Resources.Load("bunker_power_room_obj") as GameObject;

        RoomArray[0] = RoomObj_2;
        RoomArray[1] = RoomObj_3;
        RoomArray[2] = RoomObj_4;

        RandomValue1 = Random.Range(0, 3);
    }

    void Update()
    {
        if (Current_Room_Spawn_Step == 4)
        {
            RoomSpawnPointList[4] = GameObject.Find("bunker_hall_segment_3_spawnlocation");
            RoomSpawnPointList[4].name = "Room_Spawn_4";
        }

        if (Current_Room_Spawn_Step == 3)
        {
            RoomSpawnPointList[3] = GameObject.Find("bunker_hall_segment_3_spawnlocation");
            RoomSpawnPointList[3].name = "Room_Spawn_3";
        }

        if (Current_Room_Spawn_Step == 2)
        {
            RoomSpawnPointList[2] = GameObject.Find("bunker_hall_segment_3_spawnlocation");
            RoomSpawnPointList[2].name = "Room_Spawn_2";
        }

        if (Current_Room_Spawn_Step == 1)
        {
            RoomSpawnPointList[1] = GameObject.Find("bunker_hall_segment_3_spawnlocation");
            RoomSpawnPointList[1].name = "Room_Spawn_1";
        }

        RoomSpawn4 = GameObject.Find("Room_Spawn_4");
        RoomSpawn3 = GameObject.Find("Room_Spawn_3");
        RoomSpawn2 = GameObject.Find("Room_Spawn_2");
        RoomSpawn1 = GameObject.Find("Room_Spawn_1");


        //Reload the scene if any one room fails to spawn
        //(This is a very dirty but simple way to make sure the player doesnt encounter 
        // room generation bugs)





        //Room 1 Spawn Location
        Vector3 Room1SpawnLocation = new Vector3();
        Room1SpawnLocation = RoomSpawn1.transform.position;

        //Room 2 Spawn Location
        Vector3 Room2SpawnLocation = new Vector3();
        Room2SpawnLocation = RoomSpawn2.transform.position;

        //Room 3 Spawn Location
        Vector3 Room3SpawnLocation = new Vector3();
        Room3SpawnLocation = RoomSpawn3.transform.position;

        //Room 4 Spawn Location
        Vector3 Room4SpawnLocation = new Vector3();
        Room4SpawnLocation = RoomSpawn4.transform.position;

        if (Current_Room_Spawn_Step == 0)
        {
            Instantiate(RoomObj_1, Room1SpawnLocation, RoomSpawn1.transform.rotation);
            Current_Room_Spawn_Step -= 1;
        }

        if (Current_Room_Spawn_Step == -1)
        {
            Instantiate(RoomArray[RandomValue1], Room2SpawnLocation, RoomSpawn2.transform.rotation);
            Current_Room_Spawn_Step -= 1;
        }

        if (Current_Room_Spawn_Step == -2)
        {
            RandomValue2 = Random.Range(0, 3);
            if (RandomValue2 == RandomValue1)
            {
                RandomValue2 = Random.Range(0, 3);
                //while (RandomValue2 == RandomValue1)
                //{
                //    RandomValue2 = Random.Range(0, 3);
                //}
            }

            if (RandomValue2 != RandomValue1)
            {
                Instantiate(RoomArray[RandomValue2], Room3SpawnLocation, RoomSpawn3.transform.rotation);
                Current_Room_Spawn_Step -= 1;
            }
        }

        if (Current_Room_Spawn_Step == -3)
        {
            RandomValue3 = Random.Range(0, 3);
            Current_Room_Spawn_Step -= 1;
        }

        if (Current_Room_Spawn_Step == -4)
        {
            if (RandomValue3 == RandomValue1)
            {
                RandomValue3 = Random.Range(0, 3);
            }

            if (RandomValue3 == RandomValue2)
            {
                RandomValue3 = Random.Range(0, 3);
            }

            if (RandomValue3 != RandomValue1 && RandomValue3 != RandomValue2)
            {
                Instantiate(RoomArray[RandomValue3], Room4SpawnLocation, RoomSpawn4.transform.rotation);
                Current_Room_Spawn_Step -= 1;
                //gameObject.SetActive(false);
            }

            //Bugcase #1
            if (Current_Room_Spawn_Step == -5)
            {
                if (RandomValue1 == 1 && RandomValue2 == 0 && RandomValue3 == 0)
                {
                    Debug.Log("Bug Case #1 Executed");
                    Current_Room_Spawn_Step = -1;
                }

                //Bugcase #2
                if (RandomValue1 == 0 && RandomValue2 == 0 && RandomValue3 == 0)
                {
                    Debug.Log("Bug Case #2 Executed");
                    Current_Room_Spawn_Step = -1;
                }
            }
        }
    }
}
