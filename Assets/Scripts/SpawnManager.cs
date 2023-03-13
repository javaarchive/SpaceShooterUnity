using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] meteorPrefabs;

    public int secondsPerMeteorWave = 30;
    private int waveCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMeteors", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: better time tracking, but like imagine not being able to run a simple unity game
        if(Time.frameCount % (secondsPerMeteorWave * 60) == 0){
            // faster hahaha
            waveCount ++;
            Debug.Log("New Wave Starting :P Wave: " + waveCount);
            InvokeRepeating("SpawnMeteors", Random.Range(0.0f, 17.0f), 0.5f);
        }
    }

    private void SpawnMeteors(){
        // random x transform for meteor
        float randomX = Random.Range(-70f, 70f);
        GameObject meteor = meteorPrefabs[Random.Range(0, meteorPrefabs.Length)];
        Instantiate(meteor, new Vector3(randomX, 0.5f, 45f), meteor.transform.rotation);
    }

    
}
