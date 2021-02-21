using UnityEngine;


public class BoatController : MonoBehaviour
{
    [SerializeField] private Rigidbody boatRigidbody;
    public Rigidbody BoatRigidbody => boatRigidbody;
    
    [SerializeField] private float turnSpeed = 250f;

    [SerializeField] private float accellerateSpeed = 2500f;


    public float AccellerateSpeed
    {
        get => accellerateSpeed;
        set => accellerateSpeed = value;
    }


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        BoatRigidbody.AddTorque(0f,h*turnSpeed*Time.deltaTime,0f);
        BoatRigidbody.AddForce(-transform.forward*v*accellerateSpeed*Time.deltaTime);

        //Detect when the down arrow key is pressed down
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            accellerateSpeed = 1300f;
        }
        
        //Detect when the down arrow key has been released
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            accellerateSpeed = 2500f;
        }
        
    }
    
}
