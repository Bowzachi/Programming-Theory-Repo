using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private bool isTagged = false;
    public float speed = 10f;
    public float speedMultiplier = 2f;
    public float pointsValue = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Movement();
    }

    protected virtual void Movement()
    {
        //movement code calling speed and speedMultiplier
    }
}
