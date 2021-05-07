using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementSpeed : MonoBehaviour
{
    private float speed = 5f;

    private Rigidbody2D ry2D;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask Ground;

    public float jumpValue = 4f;
    private float jumpCounter;
    public float jumpTime;
    private bool isJumping;

    private void Start()
    {
        ry2D = transform.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var movement = Input.GetAxis("Horizontal");
        ry2D.velocity = new Vector2(movement*speed,ry2D.velocity.y);
        
     
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius,Ground);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space)){
            isJumping = true;
            jumpCounter = jumpTime;
            ry2D.velocity = Vector2.up * jumpValue;
        }
        
        
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpCounter > 0)
            {
                ry2D.velocity = Vector2.up * jumpValue;
                jumpCounter -= Time.deltaTime;
            } 
            else 
            {isJumping = false;}
            if (Input.GetKeyUp(KeyCode.Space))
            {
                isJumping = false;
            }

        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector2(-0.3146253f, 0.286523f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector2(0.3146253f, 0.286523f);
        }

    }




}