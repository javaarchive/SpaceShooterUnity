using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] meteorPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMeteors", 0.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnMeteors(){
        // random x transform for meteor
        float randomX = Random.Range(-70f, 70f);

        GameObject meteor = meteorPrefabs[Random.Range(0, meteorPrefabs.Length)];
        Instantiate(meteor, new Vector3(randomX, 0.5f, 45f), meteor.transform.rotation);
    }
}
