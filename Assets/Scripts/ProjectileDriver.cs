using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDriver : MonoBehaviour
{

    private float speed = 30f;
    public GameObject originShip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > 64){
            // destroy yourself
            GameObject.Destroy(this.gameObject, 1.0f);
            return;
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision coll){
        if(originShip != null){
            // while the ship is not destroyed we increment points
            ShipController shipController = originShip.GetComponent<ShipController>();
            shipController.setScore(shipController.getScore() + 1);
            Debug.Log("Points: " + shipController.getScore());
        }
        Destroy(gameObject);
        if(coll.gameObject.GetComponent<MeteorDriver>()){
            // we tell the meteor to start it's death animation
            // the more hits the faster it goes
            MeteorDriver meteorDriv = coll.gameObject.GetComponent<MeteorDriver>();
            meteorDriv.hits ++; // inc hit counter
            meteorDriv.isDying = true; // should make setter but nah
        }else{
            Debug.Log("hit object without a meteordriver");
            Destroy(coll.gameObject);
        }
        
    }
}
