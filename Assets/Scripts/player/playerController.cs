﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Example   if(Input.GetKey(GameManager.GM.forward))

    //public vars
    public float maxSpeed;
    public float jumpHeight;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public Transform origin;
    public GameObject fireBall;
    public GameObject iceShard;
    public GameObject arcaneShot;

    //private serialized vars
    [SerializeField]
    float fireRate = .25f;
    [SerializeField]
    float onGroundRadius = .2f;

    //private vars
    Rigidbody2D rb;
    Animator anim;
    projectileDamage pd;
    float nextFire = 0f;
    bool isAttack = false;
    bool fireActive;
    bool iceActive;
    bool arcaneActive;
    bool facingRight;
    bool isGrounded;

    void Awake()
    {
        GameSFX sfx = Object.FindObjectOfType<GameSFX>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingRight = true;
        fireActive = false;
        iceActive = false;
        arcaneActive = true;
    }

    void Update()
    {
        SetAttackType();

        //player jump
        if (isGrounded && Input.GetKey(Grid.gameManagerProper.jump))
        {
            isGrounded = false;
            anim.SetBool("isGrounded", isGrounded);
            rb.AddForce(new Vector2(0, jumpHeight));
            Grid.gameSFX.StartCoroutine("JumpAudio");
        }
        //player attack
        if(Input.GetKey(Grid.gameManagerProper.attack))
        {
            isAttack = true;
            if (arcaneActive)
                StartCoroutine("ArcaneAttack");
            else if (iceActive)
                StartCoroutine("IceAttack");
            else if (fireActive)
                StartCoroutine("FireAttack");
        }
    }

    void FixedUpdate()
    {
        //check if we are grounded, if not falling
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, onGroundRadius, groundLayer);

        anim.SetBool("isGrounded", isGrounded);

        anim.SetFloat("verticalSpeed", rb.velocity.y);

        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("speed", Mathf.Abs(move));

        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
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

    void SetAttackType()
    {
        if (Input.GetKey(Grid.gameManagerProper.setArcane))
        {
            arcaneActive = true;
            fireActive = false;
            iceActive = false;
            Debug.Log("Arcane Shot Active");
        }
        else if (Input.GetKey(Grid.gameManagerProper.setIce))
        {
            arcaneActive = false;
            fireActive = false;
            iceActive = true;
            Debug.Log("Ice Shard Active");
        }
        else if (Input.GetKey(Grid.gameManagerProper.setFire))
        {
            arcaneActive = false;
            fireActive = true;
            iceActive = false;
            Debug.Log("Fireball Active");
        }
    }

    IEnumerator ArcaneAttack()
    {
        //Debug.Log("Attack called");
        if (Time.time >= nextFire)
        {
            nextFire = Time.time + fireRate;
            yield return new WaitForSeconds(.1f);
            anim.SetBool("isAttacking", isAttack);

            if (facingRight)
            {
                yield return new WaitForSeconds(.15f);
                Instantiate(arcaneShot, origin.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!facingRight)
            {
                yield return new WaitForSeconds(.15f);
                Instantiate(arcaneShot, origin.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
            yield return new WaitForSeconds(.15f);
            isAttack = false;
            anim.SetBool("isAttacking", isAttack);
        }
    }

    IEnumerator IceAttack()
    {
        //Debug.Log("Attack called");
        if (Time.time >= nextFire)
        {
            nextFire = Time.time + fireRate;
            yield return new WaitForSeconds(.1f);
            anim.SetBool("isAttacking", isAttack);

            if (facingRight)
            {
                yield return new WaitForSeconds(.15f);
                Instantiate(iceShard, origin.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!facingRight)
            {
                yield return new WaitForSeconds(.15f);
                Instantiate(iceShard, origin.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
            yield return new WaitForSeconds(.15f);
            isAttack = false;
            anim.SetBool("isAttacking", isAttack);
        }
    }
    IEnumerator FireAttack()
    {
        //Debug.Log("Attack called");
        if (Time.time >= nextFire)
        {
            nextFire = Time.time + fireRate;
            yield return new WaitForSeconds(.1f);
            anim.SetBool("isAttacking", isAttack);

            if (facingRight)
            {
                yield return new WaitForSeconds(.15f);
                Instantiate(fireBall, origin.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!facingRight)
            {
                yield return new WaitForSeconds(.15f);
                Instantiate(fireBall, origin.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
            yield return new WaitForSeconds(.15f);
            isAttack = false;
            anim.SetBool("isAttacking", isAttack);
        }
    }
}
