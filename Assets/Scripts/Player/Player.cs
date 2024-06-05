using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRigidBody;

    public float velocity = 10;
    public float runningSpeed =  20;

    public float jumpForce = 20;

    public string boolRun = "run";
    public string boolRunning = "running";

    public Animator animator;

    private float _currentVelocity;

    private bool _isOnFloor;

    [Header("Death Animation")]
    public HealthBase healthBase;
    public string triggerKill = "kill";

    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;

        animator.SetTrigger(triggerKill);
    }

    private void Awake()
    {
        _isOnFloor = false;
        _currentVelocity = velocity;

        if(healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }
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
        if((Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightArrow)))
        {
            _currentVelocity = runningSpeed;

            animator.SetBool(boolRunning, true);
        }
        else
        {
            _currentVelocity = velocity;

            animator.SetBool(boolRunning, false);
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.velocity = new Vector2(-1 * _currentVelocity, myRigidBody.velocity.y);

            //gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);

            if(myRigidBody.transform.localScale.x != -1)
            {
                myRigidBody.transform.DOScaleX(-1, .1f);
            }

            animator.SetBool(boolRun, true);
        }else if(Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector2(1 * _currentVelocity, myRigidBody.velocity.y);

            //gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

            if(myRigidBody.transform.localScale.x != 1)
            {
                myRigidBody.transform.DOScaleX(1, .1f);
            }

            animator.SetBool(boolRun, true);
        }else
        {
            myRigidBody.velocity = new Vector2(0 * _currentVelocity, myRigidBody.velocity.y);

            animator.SetBool(boolRun, false);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("floor") || col.gameObject.CompareTag("enemy"))
        {
            _isOnFloor = true;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("floor") || col.gameObject.CompareTag("enemy"))
        {
            _isOnFloor = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("floor") || col.gameObject.CompareTag("enemy"))
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

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
