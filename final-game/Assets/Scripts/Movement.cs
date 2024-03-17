using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Hareket hýzý
    public float rotationSpeed = 5.0f; // Dönme hýzý
    
    private Animator animator;
    private Rigidbody rb;



    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;



    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
 
    // Update is called once per frame
    void Update()
    {

        moving();
       




    }

    void moving()
    {;
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        
        Vector3 move = new Vector3(horizontalInput, 0, verticalInput);
        moveDirection = transform.TransformDirection(move);
        moveDirection *= moveSpeed;

        




        // Karakteri yatay düzlemde döndür
        if (move != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);

            

        }
        animator.SetFloat("Speed", move.magnitude);
        characterController.Move(moveDirection * Time.deltaTime);
    }
 
}
