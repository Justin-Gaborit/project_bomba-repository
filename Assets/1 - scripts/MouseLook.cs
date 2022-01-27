using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    float sensitivityModifier = 2.5f;
    public int PickupDistance;
    Vector3 ScreenCenter;
    public Camera MainCamera;
 


    void Start()
    {
        mouseSensitivity = mouseSensitivity * sensitivityModifier;
        Cursor.lockState = CursorLockMode.Locked;

        ScreenCenter = MainCamera.ScreenToWorldPoint(new Vector3(0.5f, 0.5f, 0));
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    void FixedUpdate()
    {
        //= Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(0.5f, 0.5f, 0)), transform.TransformDirection(Vector3.forward), out);

        RaycastHit HitInfo;

        if (Physics.Raycast(MainCamera.ScreenToWorldPoint(new Vector3(0.5f, 0.5f, 0)), transform.TransformDirection(Vector3.forward), out HitInfo, PickupDistance))
        {
            if (HitInfo.collider.name == "pickaxe")
            {
                
            }
        }

    }
}
