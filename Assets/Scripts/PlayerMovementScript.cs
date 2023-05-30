using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float thrust = 20f;
    public float leftRightModifier = 1.5f;
    public float torque = 20f;
    public float slowdownRate = 0.95f;
    public float maxAngularVelocity = 10f;
    public bool controlsEnabled;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controlsEnabled = false;    
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate() {
        if (controlsEnabled) {
            if (Input.GetKey(KeyCode.Space)) {
                rb.AddForce(transform.up * thrust * Time.deltaTime, ForceMode2D.Force);
            }

            if (Input.GetKey(KeyCode.A)) {
                rb.AddForce(-transform.right * thrust * leftRightModifier * Time.deltaTime, ForceMode2D.Force);
            }

            if (Input.GetKey(KeyCode.D)) {
                rb.AddForce(transform.right * thrust * leftRightModifier * Time.deltaTime, ForceMode2D.Force);
            }

            if (Input.GetKey(KeyCode.S)) {
                rb.AddForce(-transform.up * thrust * Time.deltaTime, ForceMode2D.Force);
            }

            if (Input.GetKey(KeyCode.LeftArrow)) {
                rb.AddTorque(torque);
            }

            if (Input.GetKey(KeyCode.RightArrow)) {
                rb.AddTorque(-torque);
            }

            if (Input.GetKey(KeyCode.LeftShift)) {
                rb.velocity = rb.velocity * slowdownRate;
                rb.angularVelocity = rb.angularVelocity * slowdownRate;
            }
        }

        if(rb.angularVelocity > maxAngularVelocity) {
            rb.angularVelocity = maxAngularVelocity;
        }

        if(rb.angularVelocity < -maxAngularVelocity) {
            rb.angularVelocity = -maxAngularVelocity;
        }
    }
    public void enableControls(bool b) {
        controlsEnabled = b;
    }

    public bool areControlsEnabled() {
        return controlsEnabled;
    }
}