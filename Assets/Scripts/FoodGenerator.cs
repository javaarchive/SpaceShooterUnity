using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{

    public GameObject[] foods;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFoods", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnFoods(){
        // random x transform for meteor
        float randomX = Random.Range(-35f, -10f);
        GameObject food = foods[Random.Range(0, foods.Length)];
        Instantiate(food, new Vector3(randomX, transform.position.y, transform.position.z), food.transform.rotation);
    }
}
