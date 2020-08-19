using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("сontrol")]

public class PlayerController : MonoBehaviour
{
    //public enum RotationAxes
    //{
    //    MouseXAndY = 0,
    //    MouseX = 1,
    //    MouseY = 2
    //}
    //public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivity = 9.0f;    
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;    
    float rotX, rotY;
    float _rotationX = 0;
    float _rotationY = 0;
    float horizontal, vertical;
    public float speed = 6.0f;
    //public float gravity = -9.8f;
    CharacterController character;
    public bool webGLRightClickRotation = true;
    public GameObject cam;    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;       

        character = GetComponent<CharacterController>();
        if (Application.isEditor)
        {
            webGLRightClickRotation = false;                        
        }        
    }   
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal") * speed;
        vertical = Input.GetAxis("Vertical") * speed;

        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY = Input.GetAxis("Mouse Y") * sensitivity;

        if (Time.timeScale != 0)
        {
            if (webGLRightClickRotation)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    CameraRotation(cam, rotX, rotY);
                }
            }
            else if (!webGLRightClickRotation)
            {
                CameraRotation(cam, rotX, rotY);
            }
        }

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        movement = transform.rotation * movement;         
        character.Move(movement * Time.deltaTime);
    }
    public void CameraRotation(GameObject cam, float rotX, float rotY)
    {
        //if (axes == RotationAxes.MouseX)
        //{
        //    transform.Rotate(0, rotX, 0);
        //}
        //else if (axes == RotationAxes.MouseY)
        //{
        //    _rotationX -= rotY;
        //    _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
        //    float _rotationY = transform.localEulerAngles.y;
        //    cam.transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        //}

        //_rotationX -= rotY;
        //_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
        //float delta = rotX;
        //float _rotationY = transform.localEulerAngles.y + delta;
        //transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);

        _rotationX = transform.localEulerAngles.y + rotX;
        _rotationY += rotY;
        _rotationY = Mathf.Clamp(_rotationY, minimumVert, maximumVert);
        transform.localEulerAngles = new Vector3(-_rotationY, _rotationX, 0);
    }
}
