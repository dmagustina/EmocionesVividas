using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehaviour : MonoBehaviour {

    public Vector3 jump;

    public Vector3 left { get; private set; }
    public Vector3 right { get; private set; }

public float jumpForce = 2.0f;

    public bool isGrounded;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        left = new Vector3(-2.0f, 0.0f, 0.0f);
        right = new Vector3(2.0f, 0.0f, 0.0f);

    }

    void OnCollisionStay2D()
    {
        isGrounded = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(left, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(right, ForceMode2D.Impulse);
        }
    }
}
