using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float speed;
    public Transform head;
    public AudioSource sorce;
    public AudioClip footSteps;     
    
    private Rigidbody body;
    private Vector3 direction;
    private float sensitivity = 5f;
    private float headMinY = -40f;
    private float headMaxY = 40f;
    private float footstepTime = 0.7f;
    private float _spawnSpeed = 5.0f;
    private float _h, _v;
    private float _rotationY;
    private float timeout;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        sorce = GetComponent<AudioSource>();
        body.freezeRotation = true;      
        Cursor.lockState = CursorLockMode.Locked;
        speed = _spawnSpeed;
    }

    private void FixedUpdate()
    {
        body.AddForce(direction * speed, ForceMode.VelocityChange);

        //Ограничение скорости, иначе объект будет постоянно ускоряться
        if (Mathf.Abs(body.velocity.x) > speed)
        {
            body.velocity = new Vector3(Mathf.Sign(body.velocity.x) * speed, body.velocity.y, body.velocity.z);
        }
        if (Mathf.Abs(body.velocity.z) > speed)
        {
            body.velocity = new Vector3(body.velocity.x, body.velocity.y, Mathf.Sign(body.velocity.z) * speed);
        }

    }
    private void Update()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");       

        if (Time.timeScale != 0)
        {
            CameraRotation();
        }       

        timeout += Time.deltaTime;
        if (Input.GetButton("Horizontal")& timeout >= footstepTime || Input.GetButton("Vertical")& timeout >= footstepTime)
        {
            timeout = 0;
            sorce.PlayOneShot(footSteps);
        }
        //ускорение
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 8.0f;
            footstepTime = 0.3f;
        }
        else
        {
            speed = _spawnSpeed;
            footstepTime = 0.7f;
        }
        //вектор направления движения
        direction = new Vector3(_h, 0, _v);
        direction = head.TransformDirection(direction);
        direction = new Vector3(direction.x, 0, direction.z);        
    }
    private void CameraRotation()
    {
        //управление головой (камерой)
        float _rotationX = head.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
        _rotationY += Input.GetAxis("Mouse Y") * sensitivity;
        _rotationY = Mathf.Clamp(_rotationY, headMinY, headMaxY);
        head.localEulerAngles = new Vector3(-_rotationY, _rotationX, 0);
    }
}