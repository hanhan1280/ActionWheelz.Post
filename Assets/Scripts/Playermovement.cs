/* File: Playermovement
 * Description: move user using ASD keys, check if player grounded, allows for ramp physics
 * written by Hanan Au 
 */
using UnityEngine;


public class Playermovement : MonoBehaviour {

    public Rigidbody rb;

    public LayerMask ground;
    
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    public float speed = 0.99f;
    public float fallspeed = 2.5f;
    public float rampHeight;

    RaycastHit hitInfo;
   
    bool grounded;
   
   

    private void Update()
    {
        
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallspeed-1) * Time.deltaTime; 
        }
    }

    // FixedUpdate since we are dealing with physics
    void FixedUpdate()
    {
         //apply a force in the z axis by time since com drew last frame
        rb.AddForce(0,0,forwardForce * Time.deltaTime);
        

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            //velocity change is used since force increases exponentially from 0, and will not be fluid if player changes directions
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (grounded && Input.GetKey("s"))
        {
            rb.velocity = rb.velocity * speed;            
        }
       

        
        if (rb.position.y < -1f)
        {
           FindObjectOfType<GameManager>().EndGame(); // if it goes below certain y, endgame
        }
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.gameObject.name == "ground" || collision.gameObject.CompareTag("ramp"))
        {
            grounded = true;
            if(collision.gameObject.name == "ground")
            {
                Quaternion rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
                transform.rotation = rotation;
            }
        }
        
    }

    private void OnCollisionExit(UnityEngine.Collision collision)
    {
        if (collision.gameObject.name == "ground" || collision.gameObject.CompareTag("ramp"))
        {
            grounded = false;
        }
    }
}
 