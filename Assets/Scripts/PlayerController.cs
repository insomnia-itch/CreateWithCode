using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //private float speed = 20f;
    [SerializeField] private float horsePower = 0f;
    private float turnSpeed = 45f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody rb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float speed;
    [SerializeField] float rpm;
    [SerializeField] List<WheelCollider> allWheels;
    int wheelsOnGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsOnGround())
        {

            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");
            // Move the vehicle forward
            rb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            transform.Rotate(Vector3.up* Time.deltaTime * turnSpeed * horizontalInput);
            speed = Mathf.Round(rb.velocity.magnitude * 2.237f);
            speedometerText.SetText("Speed: " + speed + "mph");
            rpm = Mathf.Round(speed % 30) * 40;
            rpmText.SetText("RPM: " + rpm);
        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
