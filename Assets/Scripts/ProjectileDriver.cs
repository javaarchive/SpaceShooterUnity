using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDriver : MonoBehaviour
{

    private float speed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > 64){
            // destroy yourself
            // ocd
            GameObject.Destroy(this.gameObject, 1.0f);
            return;
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
