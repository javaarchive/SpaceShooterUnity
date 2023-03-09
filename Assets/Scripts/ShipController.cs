using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private float horizontal;
    private float speed2 = 0f;

    private float maxSpeed = 60f;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Debug.Log("Speed: " + speed2 + " " + horizontal);
        speed2 = Mathf.Clamp(speed2 + horizontal,-maxSpeed,maxSpeed);
        if(Mathf.Abs(horizontal) < 0.1f){
            // Decel
            speed2 = Mathf.Sign(speed2) * Mathf.Floor(Mathf.Abs(speed2) * Mathf.Pow(0.99f, Time.deltaTime));
        }
        transform.Translate(Vector3.right * Time.deltaTime * speed2);
        
        // apply walls cycle        
        if(transform.position.x < -70){
            transform.position = new Vector3(70, transform.position.y, transform.position.z);
        }else if(transform.position.x > 70){
             transform.position = new Vector3(-70, transform.position.y, transform.position.z);
        }
        // Shooter
        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
    }
}
