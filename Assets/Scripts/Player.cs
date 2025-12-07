    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    public class player : MonoBehaviour
    {
        [SerializeField]
        private float spd = 100f;
        [SerializeField]
        private float turnSpd = 1000f;
        [SerializeField]
        private float brakeF = 50f;    
        private float moveInput;
        private Rigidbody rb;
        private float turnInput;



        private void Start()
        {
            rb = GetComponent<Rigidbody>(); 
        }
        private void FixedUpdate()
        {
            moveInput = Input.GetAxis("Vertical");
            turnInput = Input.GetAxis("Horizontal");
            move();
            turn();
            if (moveInput>0 && Input.GetKey(KeyCode.Space))
            {
                brake();
            }
        }
        private void move()
        {
            rb.AddRelativeForce(Vector3.forward * moveInput * spd);
        }
        private void turn()
        {
            Quaternion turnRotation = Quaternion.Euler(Vector3.up * turnInput * turnSpd * Time.deltaTime);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
        private void brake()
        {
            if(rb.linearVelocity.z != 0)
            {
                
                rb.AddRelativeForce(-Vector3.forward * brakeF);
            }   
        }
    }
