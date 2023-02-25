using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horsePower = 1f;
    [SerializeField] private float turnSpeed = 60f;
    [SerializeField] private float maxSpeed = 10f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    [SerializeField] private GameObject playerProjectile;
    [SerializeField] private Transform fireEmitPoint;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && MainManager.Instance.GetIsGamePlaying())
        {
            FireProjectile();
        }
    }

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        //Move the vehicle forward
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        if (MainManager.Instance.GetIsGamePlaying())
        {
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
        }
    }

    private void FireProjectile()
    {
        //instantiate or enable the projectile prefab
        Instantiate(playerProjectile, fireEmitPoint.position, transform.localRotation);
    }
}
