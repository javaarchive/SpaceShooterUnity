using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private float horizontal;
    private float speed2 = 0f;

    // run the death animation
    private bool isDying = false;

    private float maxSpeed = 60f;

    public GameObject projectilePrefab;

    public const int LOOP_BOUND = 70; 

    public Vector3 shrinkMultiply = new Vector3(0.9f,0.9f,0.9f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Dying(){
        // apply death animation
        Debug.Log("animate death " + transform.localScale.x);
        if(transform.localScale.x < 0.2){
            // destroy self
            Destroy(gameObject);
        }else{
            // become smol-er
            // todo: fix math to not be that framerate dependent
            transform.localScale = Vector3.Scale(transform.localScale,shrinkMultiply);
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        // Debug.Log("Speed: " + speed2 + " " + horizontal);
        // * 100 hack for instant control
        speed2 = Mathf.Clamp(speed2 + horizontal * 100,-maxSpeed,maxSpeed);
        if(Mathf.Abs(horizontal) < 0.1f){
            // Decel
            // orig 0.99 but that was too slippery
            speed2 = Mathf.Sign(speed2) * Mathf.Floor(Mathf.Abs(speed2) * Mathf.Pow(0.5f, Time.deltaTime * 100));
        }
        transform.Translate(Vector3.right * Time.deltaTime * speed2);
        
        // apply walls cycle        
        if(transform.position.x < -LOOP_BOUND){
            transform.position = new Vector3(70, transform.position.y, transform.position.z);
        }else if(transform.position.x > LOOP_BOUND){
             transform.position = new Vector3(-70, transform.position.y, transform.position.z);
        }
        // Shooter
        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
        
    }

    private void OnCollisionEnter(Collision coll){
        Debug.Log("died!");
        // totally not a cheat code
        if(!Input.GetKey(KeyCode.RightShift)){
            // if we are not dying start shrinker
            if(!isDying) InvokeRepeating("Dying", 0.5f, 0.1f);
            isDying = true;
        }
        // legacy code to instant die
        // Destroy(gameObject);
        Destroy(coll.gameObject);
    }
}
