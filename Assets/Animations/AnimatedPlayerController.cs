using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedPlayerController : MonoBehaviour
{
    private Animator anim;
    public GameObject dish;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Throw");
        }
    }

    public void SpawnDish()
    {
        Instantiate(dish, new Vector3(transform.position.x - 8, -7.5f, -5), dish.transform.rotation);
    }
}
