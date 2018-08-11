using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementController : MonoBehaviour
{

    //purpose of script is to have the enemy move toward the player without adding a collider. 
    //It will detect the tag within a certain range and once the player is in range it will move toward the player.


    //public vars
    public float enemySpeed;
    public float wallLeft = 0.0f;
    public float wallRight = 5.0f;
    public GameObject enemyGraphic; //for facing

    //private vars
    Animator anim;
    Vector3 walkAmount;
    float walkingDir = 1.0f;
    bool facingRight;

    /*  This didn't work, hold for further testing if needed.
    public GameObject FindPlayer()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector2 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if(curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
    */
    void Start()
    {
        anim = GetComponent<Animator>();
        facingRight = true;

    }


    void Update()
    {
        walkAmount.x = walkingDir * enemySpeed * Time.deltaTime;
        if (walkingDir < 0.0f && transform.position.x <= wallLeft)
        {
            walkingDir = 1.0f;
            Flip();
        }
        
        else if (walkingDir > 0.0f && transform.position.x >= wallRight)
        {
            walkingDir = -1.0f;
            Flip();
        }
        transform.Translate(walkAmount);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 flipScale = transform.localScale;

        flipScale.x *= -1;

        transform.localScale = flipScale;
    }
        
}
