using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private bool isTagged = false;
    public float speed = 0.2f;
    public float speedBonus = 1f;
    private int pointsValue = 1;
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
        if (isTagged)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * (speed + speedBonus));
        }
        else
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void Tagged()
    {
        isTagged = true;
        gameObject.GetComponent<CapsuleCollider>().enabled= false;
        Debug.Log("Tagged for " + pointsValue);
        ScoreManager.Instance.IncreaseScore(pointsValue);
    }
}
