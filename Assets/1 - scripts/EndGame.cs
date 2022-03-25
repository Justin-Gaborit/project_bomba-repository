using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider colides)
    {
        if (colides.gameObject.tag == "Player")
        {
            Debug.Log("IT WORKED M8!!!");
            SceneManager.LoadScene("End Scene");
        }
    }
}
