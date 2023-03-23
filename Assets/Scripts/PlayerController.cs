using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // CLASS VARIABLES

    // public Class variables
    public float runSpeed = 1;
    public float strafeSpeed = 1;
    public float jumpForce = 1;
    public bool isAlive = false;
    public int distanceTraveled;

    // private class variables
    private float initialPosition;

    // Private components
    private Rigidbody rigidBody;
    private Animator animator;

    // METHODS
    private void FixedUpdate()
    {
        // Forward movement
        this.rigidBody.velocity = new Vector3(0, this.rigidBody.velocity.y, this.runSpeed);

        // Strafe movements
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && this.leftBoard()) // Left
        {
            this.rigidBody.velocity += Vector3.left * this.strafeSpeed;
        }
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && this.rightBoard()) // Right
        {
            this.rigidBody.velocity += Vector3.right * this.strafeSpeed;
        }

    }

    // Update is called once per frame
    void Update()
    {
        this.Jump();
        this.Distance();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.rigidBody = GetComponent<Rigidbody>();
        this.animator = GetComponentInChildren<Animator>();

        this.isAlive = true;
        this.distanceTraveled = 0;
        this.initialPosition = this.transform.position.z;
    }

    public void Reset()
    {
        this.isAlive = true;
        this.transform.position = new Vector3(0, 0.5f, -72);
        this.GetComponent<EnergyController>().currentEnergy = 50;
        this.distanceTraveled = 0;
    }

    private void Distance()
    {
        this.distanceTraveled = (int)((this.transform.position.z - this.initialPosition) / 5);
    }

    private void Jump()
    {
        this.animator.SetBool("IsGrounded", true);
        this.animator.SetBool("IsJumping", false);

        if (Input.GetKeyDown(KeyCode.Space) && this.isGroundedCheck())
        {
            this.animator.SetBool("IsJumping", true);
            this.animator.SetBool("IsGrounded", false);
            this.rigidBody.AddForce(Vector3.up * this.jumpForce, ForceMode.Impulse);
        }
    }

    private bool isGroundedCheck() // Checks if the Runner is on the ground
    {
        // Defines start point of the ray
        Vector3 pos = this.transform.position + Vector3.up * 0.1f;

        // Defines the ray origin and direction 
        Ray ray = new Ray(pos, Vector3.down);

        // Casts a Ray of 0.5 unit max
        bool isGrounded = Physics.Raycast(ray.origin, ray.direction, 0.5f);

        this.animator.SetBool("IsGrounded", isGrounded);

        return isGrounded;
    }

    private bool rightBoard()
    {
        if (this.transform.position.x < 23.5f)
        {
            return true;
        }
        return false;
    }

    private bool leftBoard()
    {
        if (this.transform.position.x > -23.5f)
        {
            return true;
        }
        return false;
    }

}
