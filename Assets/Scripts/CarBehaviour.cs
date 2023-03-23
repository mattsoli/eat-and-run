using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    public bool rightSide = true;
    public float carSpeed = 1;

    private Rigidbody rigidBody;

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerController>().isAlive = false;
        }
    }

    private void FixedUpdate()
    {
        if (this.rightSide)
        {
            this.rigidBody.velocity = Vector3.forward * this.carSpeed;
        }
        else
        {
            this.rigidBody.velocity = Vector3.back * this.carSpeed;
        }
    }

    void Start()
    {
        this.rigidBody = GetComponent<Rigidbody>();
    }
}
