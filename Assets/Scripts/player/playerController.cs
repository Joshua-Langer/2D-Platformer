using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    //movement vars
    public float maxSpeed;

    //jumping vars
    bool isGrounded = false;
    [SerializeField]
    float onGroundRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    //private vars
    Rigidbody2D rb;
    Animator anim;
    bool facingRight;
    projectileDamage PD;
    playerAudio playerSounds;

    //fire vars
    public Transform origin;
    public GameObject fireBall;
    [SerializeField]
    float fireRate = .25f;
    float nextFire = 0f;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingRight = true;
        playerSounds = GetComponent<playerAudio>();
	}
	
	// Always called a specific time
    void Update()
    {
        if(isGrounded && Input.GetAxis("Jump")>0)
        {
            isGrounded = false;
            anim.SetBool("isGrounded", isGrounded);
            rb.AddForce(new Vector2(0, jumpHeight));
            playerSounds.StartCoroutine("JumpAudio");
        }

        //player shoot
        if(Input.GetAxisRaw("Fire1") == 1)
        {
            throwFireBall();
        }
        //Debug.Log(transform.position.x);
    }


	void FixedUpdate ()
    {
        //check if we are grounded, if not falling
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, onGroundRadius, groundLayer);

        anim.SetBool("isGrounded", isGrounded);

        anim.SetFloat("verticalSpeed", rb.velocity.y);

        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("speed", Mathf.Abs(move));

        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        if (move >0 && !facingRight)
        {
            Flip();
        }
        else if (move<0 && facingRight)
        {
            Flip();
        }
	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 flipScale = transform.localScale;

        flipScale.x *= -1;

        transform.localScale = flipScale;
    }

    void throwFireBall()
    {
        if(Time.time >= nextFire)
        {
            nextFire = Time.time + fireRate;

            if(facingRight)
            {
                Instantiate(fireBall, origin.position, Quaternion.Euler (new Vector3(0,0,0)));
            }
            else if (!facingRight)
            {
                Instantiate(fireBall, origin.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
    }
}
