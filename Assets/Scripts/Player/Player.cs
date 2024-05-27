using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRigidBody;

    public float velocity = 10;
    public float runningSpeed =  20;

    public float jumpForce = 20;

    private float _currentVelocity;

    private bool _isOnFloor;

    private void Awake()
    {
        _isOnFloor = false;
        _currentVelocity = velocity;
    }

    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
        Movement();
    }

    public void Movement()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            _currentVelocity = runningSpeed;
        }
        else
        {
            _currentVelocity = velocity;
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.velocity = new Vector2(-1 * _currentVelocity, myRigidBody.velocity.y);

            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }else if(Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector2(1 * _currentVelocity, myRigidBody.velocity.y);

            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }else
        {
            myRigidBody.velocity = new Vector2(0 * _currentVelocity, myRigidBody.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("floor"))
        {
            _isOnFloor = true;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("floor"))
        {
            _isOnFloor = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("floor"))
        {
            _isOnFloor = false;
        }
    }

    public void Jump()
    {
        if(_isOnFloor)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                myRigidBody.velocity = Vector2.up * jumpForce;
            }
        }
    }
}
