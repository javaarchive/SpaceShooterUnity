using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorDriver : MonoBehaviour
{

    private float speed = 30f;

    public bool isDying = false;

    public int hits = 0;

    public float dyingScaleDown = 0.5f;
    public float dyingRemoveThreshold = 0.1f;

    public const int DISCARD_THRESHOLD = -70;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < DISCARD_THRESHOLD){
            // destroy yourself
            // ocd
            GameObject.Destroy(this.gameObject, 1.0f);
            return;
        }else if(isDying){
            if(transform.localScale.x <= dyingRemoveThreshold){
                // nuke when we pass threshold
                Destroy(this, 1.0f);
            }else if(Time.frameCount % 3 == 0){ // this is such a troll piece of code every 3 frames we scale down
                float multiplier = Mathf.Pow(dyingScaleDown, hits);
                transform.localScale = Vector3.Scale(transform.localScale, new Vector3(multiplier,multiplier,multiplier));
            }
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed * -1);
    }
}
