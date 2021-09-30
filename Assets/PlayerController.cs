using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera viewCamera;
    public float life = 100;

    private Rigidbody rb;
    public bool doubleJumped = false;
    public bool groundedPlayer = true;
    private float playerSpeed = 5.0f;
    private float jumpForce = 5.0f;
    private Animator anim;
    private bool hit;
    private float hitTime = 0;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hit)
        {
            this.transform.eulerAngles = new Vector3(0, viewCamera.transform.eulerAngles.y, 0);
            life -= Time.deltaTime;
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * playerSpeed;
            Vector3 inputDirection = move.normalized;
            if (inputDirection.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + viewCamera.transform.eulerAngles.y; // atan2 returns the angle in radian
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
            }
            if (Input.GetButtonDown("Jump") && (groundedPlayer || !doubleJumped))
            {
                move.y = jumpForce;
                if (!groundedPlayer)
                {
                    doubleJumped = true;
                }
            }
            else
            {
                move.y = rb.velocity.y;
            }

            move = Quaternion.Euler(0, viewCamera.transform.eulerAngles.y, 0) * move;
            rb.velocity = move;

            if (Input.GetButtonDown("Fire1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
            {
                anim.Play("attack");
            }
        } else
        {
            hitTime -= Time.deltaTime;
            if (hitTime <= 0)
            {
                hit = false;
            }
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        for( int i = 0; i < collision.contactCount; i++)
        {
            if (collision.GetContact(i).thisCollider.gameObject.name == "Player")
            {
                if (collision.gameObject.tag == "ground" && collision.GetContact(0).normal.y > 0.85)
                {
                    groundedPlayer = true;
                    doubleJumped = false;
                }
                if (collision.gameObject.tag == "pickup")
                {
                    Destroy(collision.gameObject);
                    life += 5;
                }
                if (collision.gameObject.tag == "enemy" && !hit)
                {
                    life -= 10;
                    rb.velocity = collision.GetContact(0).normal* playerSpeed*2;
                    hit = true;
                    hitTime = 1f;
                }
            } else if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack") && collision.GetContact(i).thisCollider.gameObject.name == "weapon")
            {
                if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "destructable")
                {
                    Destroy(collision.gameObject);
                }
            }
        }        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            groundedPlayer = false;
        }
    }
}
