using UnityEngine;

public class SpaceshipController : MonoBehaviour
{    
    public GameObject cam;
    public GameObject particles;
    public AudioClip engine;
    private float sensitivity = 9.0f;
    private float minimumVert = -45.0f;
    private float maximumVert = 45.0f;
    private float speed = 9.0f;
    public float stepTime = 0.5f;
    private float _rotationX = 0;
    private float _rotY;    
    private float _vertical;
    private float timeout;
    private CharacterController character;
    private AudioSource machineAudio;

    private void Start()
    {
        character = GetComponent<CharacterController>();       
        machineAudio = GetComponent<AudioSource>();

        Cursor.lockState = CursorLockMode.Locked;  
    }

    private void Update()
    { 
        _vertical = Input.GetAxis("Vertical") * speed;
        _rotY = Input.GetAxis("Mouse Y") * sensitivity;

        if (Time.timeScale != 0)
        {
            CameraRotation(cam, _rotY);
        }

        Vector3 movement = new Vector3(0, 0, _vertical);
        movement = transform.rotation * movement;
        character.Move(movement * Time.deltaTime);

        //particles
        if (Input.GetKey(KeyCode.W))
        {            
            particles.SetActive(true);
        }
        else
        {
            particles.SetActive(false);
        }

        //sound
        timeout += Time.deltaTime;
        if (Input.GetButton("Vertical") && timeout >= stepTime)
        {
            timeout = 0;
            machineAudio.PlayOneShot(engine);
        }        
    }
    private void CameraRotation(GameObject cam, float rotY)
    {
        _rotationX -= rotY;
        _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
        float _rotationY = transform.localEulerAngles.y;
        cam.transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
    } 
}

