using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 2f;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * projectileSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("think we touched a collider");
        Destroy(gameObject);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        Fish fish = other.GetComponent<Fish>();
        //Debug.Log("think we entered a trigger");
        if (fish != null)
        {
            fish.Tagged();
            Debug.Log("Think we hit a fish");
            Destroy(gameObject);
        }
    }
}
