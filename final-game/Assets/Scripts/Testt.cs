using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testt : MonoBehaviour
{
    public float speed = 5f; // Hareket hýzý

    private Rigidbody rb;
    private Animator animator;
    private bool rightpress, leftpress,isJumping;
    private float JumpForce = 25f;
    private bool hasRotated = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        //var velocity = (Vector3.forward * verticalInput + Vector3.right * horizontalInput) * speed;
        //rb.velocity = velocity;

        //animator.SetFloat("Speed", velocity.magnitude);



        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        var velocity = (Vector3.forward * verticalInput + Vector3.right * horizontalInput) * speed;
        rb.velocity = velocity;

        animator.SetFloat("Speed", velocity.magnitude);

        // Anlýk dönüþ için:
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 90f, transform.rotation.eulerAngles.z);


        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, -90f, transform.rotation.eulerAngles.z);


        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);

           
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z);


        }
     
        
        
    }
}
