using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchableDriver : MonoBehaviour
{

    private int aliveFrames = 0;

    private const int DESPAWN_FRAMES = 60 * 10;

    public int newtonsOfForce = 10000;

    // Start is called before the first frame update
    void Start()
    {
        this.aliveFrames = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.aliveFrames ++;
        if(this.aliveFrames > DESPAWN_FRAMES){
            Destroy(gameObject, 1f);
        }
        // apply force
        this.GetComponent<Rigidbody>().AddForce(Vector3.left * Time.deltaTime * newtonsOfForce, ForceMode.Force); 
    }

    private void OnCollisionEnter(Collision coll){
        if(coll.gameObject.GetComponent<CatchableDriver>()){
            // don't delete other plates/dinnerware
            return;
        }
        Debug.Log("gj you caught a plate");
        Destroy(coll.gameObject, 1f);
        Destroy(this.gameObject, 1f);
    }
}
