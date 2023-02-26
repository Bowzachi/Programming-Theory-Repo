using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private bool isTagged = false;
    [SerializeField] private float speed = 0.2f;
    [SerializeField] private float speedBonus = 1f;
    [SerializeField] private int pointsValue = 1;
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

    //Putting movement in its own overrideable method ABSTRACTION
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
        AdditionalOnTagged(); //adding virtual method for override-able additional effects on projectile hit. POLYMORPHISM
        isTagged = true;
        gameObject.GetComponent<CapsuleCollider>().enabled= false;
        //Debug.Log("Tagged for " + pointsValue);
        ScoreManager.Instance.IncreaseScore(pointsValue);
    }

    //adding virtual method for override-able additional effects on projectile hit. POLYMORPHISM
    protected virtual void AdditionalOnTagged()
    {
        //Debug.Log("Default Fish class referenced for AdditionalOnTagged!");
    }
}
