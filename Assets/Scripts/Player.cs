using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator animator;

    public float moveSpeed = 3f;
    private bool isMoving = false;
    private bool cantMove = false;

    private float x;
    private float y;

    private Vector2 input;



    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        GetInput();
        Animate();
    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = input * moveSpeed;
    }

    private void GetInput()
    {
        if (cantMove != true)
        {
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");

            input = new Vector2(x, y);
            input.Normalize();
        }
    }
    private void Animate()
    {
        if (input.magnitude > 0.1f || input.magnitude < -0.1f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            animator.SetFloat("X", x);
            animator.SetFloat("Y", y);
        }

        animator.SetBool("isMoving", isMoving);
    }
    public void SetCantMove(bool value)
    {
        cantMove = value;
    }
}
