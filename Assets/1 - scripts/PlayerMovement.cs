using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Camera playercamera_obj;
    public float camera_fov;
    private bool camera_is_zoomed;

    //Character Controller Elements
    public CharacterController controller;
    public float playerheight;
    public float speed = 12f;
    public float crouchspeed = 3f;
    public float gravity = -9.81f;
    Vector3 velocity;
    public float jumpHeight = 3f;

    //Sneak UI Element
    public GameObject ui_sneak_border_obj;
    public Image ui_sneak_border_spr;
    public string ui_sneak_border_name;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public bool iscrouched;

    void Camera_Zoomin()
    {
        DOTween.To(() => playercamera_obj.fieldOfView, x => playercamera_obj.fieldOfView = x, 35f, 0.5f);
    }
    void Camera_Zoomout()
    {
        DOTween.To(() => playercamera_obj.fieldOfView, x => playercamera_obj.fieldOfView = x, camera_fov, 0.5f);
    }

    /// <summary>
    /// Fades in the ui_sneak_border_obj
    /// </summary>
    void Ui_Sneak_FadeIn()
    { 
      ui_sneak_border_spr.DOFade(1f, 1.8f); 
      DOTween.To(() => playerheight, x => playerheight = x, 1.4f, 0.5f);
      DOTween.To(() => speed, x => speed = x, crouchspeed, 0.5f);
    }

    /// <summary>
    /// Fades out the ui_sneak_border_obj
    /// </summary>
    void Ui_Sneak_FadeOut()
    { 
      ui_sneak_border_spr.DOFade(0f, 1.8f);
      DOTween.To(() => playerheight, x => playerheight = x, 2.89f, 0.5f);
      DOTween.To(() => speed, x => speed = x, 6, 0.5f);
    }

    void Start()
    {
        //Dont change any of the object names listed here or script will not be able to find the UI sneak border
        
        ui_sneak_border_obj = GameObject.Find("Player Character/Camera/User Interface/Canvas/ui_sneak_border");
        ui_sneak_border_name = ui_sneak_border_obj.name;
        ui_sneak_border_spr = ui_sneak_border_obj.GetComponent<Image>();
        var ui_sneak_border_color = ui_sneak_border_spr.color;
        ui_sneak_border_color.a = 0f;
        ui_sneak_border_spr.color = ui_sneak_border_color;

        iscrouched = false;
        camera_is_zoomed = false;

        camera_fov = 70f;
        playerheight = 2.89f;
    }

    void Update()
    {
        controller.height = playerheight;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //Running
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x +transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //Jump while standing
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        //Jump while crouching
        if (Input.GetButtonDown("Jump") && isGrounded && iscrouched)
        {
            iscrouched = false;
            Ui_Sneak_FadeOut();
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        //Crouching
        if (Input.GetKeyDown(KeyCode.LeftControl) && iscrouched == false)
        {
            IEnumerator iscrouched_coroutine()
            {
                yield return new WaitForSeconds(0.1f);
                iscrouched = true;
            }

            //controller.height = 1.4f;
            StartCoroutine(iscrouched_coroutine());
            Ui_Sneak_FadeIn();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && iscrouched == true)
        {
            controller.height = 2.89f;
            iscrouched = false;
            Ui_Sneak_FadeOut();
        }

        if (Input.GetMouseButtonDown(1))
        {
            IEnumerator iszoomedin_coroutine()
            {
                yield return new WaitForSeconds(0.1f);
                camera_is_zoomed = true;
            }
            StartCoroutine(iszoomedin_coroutine());
            Camera_Zoomin();
        }

        if (Input.GetMouseButtonUp(1))
        {
            Camera_Zoomout();
        }
    }
}
