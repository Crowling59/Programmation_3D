using UnityEngine;


public class BoatController : MonoBehaviour //Permet de controller le bateau
{
    [SerializeField] private Rigidbody boatRigidbody;
    public Rigidbody BoatRigidbody => boatRigidbody;
    
    [SerializeField] private float turnSpeed = 250f;

    [SerializeField] private float accelerateSpeed = 2500f;


    public float AccelerateSpeed
    {
        set => accelerateSpeed = value;
    }


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Lock du curseur au départ de la scène
    }
    
    void Update()
    {
        //Cette partie permet de déplacer le bateau
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        BoatRigidbody.AddTorque(0f,h*turnSpeed*Time.deltaTime,0f);
        BoatRigidbody.AddForce(-transform.forward*v*accelerateSpeed*Time.deltaTime);

        //Cette partie permet au bateau d'être plus lent quand il recule
        //Détecte quand la flèche du bas est pressée
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            accelerateSpeed = 1300f;
        }
        
        //Détecte quand la flèche du bas est relachée
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            accelerateSpeed = 2500f;
        }
        
    }
    
}
