using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateProducer : MonoBehaviour
{

    public Vector3 offset = new Vector3(0,3f,0);

    public GameObject[] foods;

    void FirePlate(){
        int foodIndex = Random.Range(0, foods.Length);
        GameObject newObj = Instantiate(foods[foodIndex],transform.position + offset,transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            this.FirePlate();
        }
    }
}
