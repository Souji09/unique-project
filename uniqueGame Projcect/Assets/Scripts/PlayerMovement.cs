using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    private Vector2 Movement;
    Vector2 NormalizedSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");

        NormalizedSpeed = Movement.normalized;
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + speed * NormalizedSpeed * Time.deltaTime);
    }
}
