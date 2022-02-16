using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor4WallGeneration : MonoBehaviour
{
    public GameObject[] WallArray;
    public GameObject WallSpawnLocation;
    public int RandomValue;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWalls());
    }

    IEnumerator SpawnWalls()
    {
        yield return new WaitForSeconds(.5f);

        WallArray[0] = Resources.Load("silo_wall_1_model_obj") as GameObject;
        WallArray[1] = Resources.Load("silo_wall_2_model_obj") as GameObject;
        WallArray[2] = Resources.Load("silo_wall_3_model_obj") as GameObject;
        WallArray[3] = Resources.Load("silo_wall_1_model_obj") as GameObject;
        WallArray[4] = Resources.Load("silo_wall_2_model_obj") as GameObject;
        WallArray[5] = Resources.Load("silo_wall_3_model_obj") as GameObject;
        WallArray[6] = Resources.Load("silo_wall_1_model_obj") as GameObject;
        WallArray[7] = Resources.Load("silo_wall_2_model_obj") as GameObject;
        WallArray[8] = Resources.Load("silo_wall_3_model_obj") as GameObject;
        WallArray[9] = Resources.Load("silo_wall_1_model_obj") as GameObject;
        WallArray[10] = Resources.Load("silo_wall_2_model_obj") as GameObject;
        WallArray[11] = Resources.Load("silo_wall_3_model_obj") as GameObject;

        Vector3 SpawnLocation = new Vector3();
        SpawnLocation = WallSpawnLocation.transform.position;
        RandomValue = Random.Range(0, 3);
        Instantiate(WallArray[RandomValue], SpawnLocation, Quaternion.identity);

        Debug.Log("wall instantiated");
    }
}
