using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public void setGoal(Vector3 newGoal){
        this.goal = newGoal;
    }

    public void setGoalRot(Vector3 newGoalRot){
        this.goalRot = newGoalRot;
    }
    private Vector3 goal;
    private Vector3 goalRot;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f,5.7f,-28.2f);
        goal = new Vector3(-8f,2.7f,-45.2f);
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: not tie to framerate
        this.transform.Translate((this.goal - this.transform.position) * 0.01f);
    }

    
}
