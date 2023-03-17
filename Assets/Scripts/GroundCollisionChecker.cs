using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollisionChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision coll){
        Debug.Log("oh it looks like you died! :( ");
        Destroy(coll.gameObject, 1f);
    }
}
