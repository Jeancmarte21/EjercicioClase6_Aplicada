using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    GameObject player;
    float walkSpeed = 2.5f, runSpeed = 5, maxSpeed;
    Rigidbody rbody;
    Vector3 speed;
    bool isAttacking;
    Animator animator;
    SpriteRenderer spriteRenderer;
    const float MINENEMYATTACKDISTANCE = 1f, MINENEMYCHASEDISTANCE = 5f;
    float distance;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(gameObject.tag == "Enemy")
        {
            distance = Vector3.Distance(gameObject.transform.position, player.transform.position);

            if (distance < MINENEMYCHASEDISTANCE && distance > MINENEMYATTACKDISTANCE)
            {
                speed = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, walkSpeed * Time.deltaTime);
                Debug.Log(speed);
                isAttacking = false;
            }
            else if(distance < MINENEMYATTACKDISTANCE)
            {
                speed = Vector3.zero;
                isAttacking = true;
            }
            else
            {
                speed = Vector3.zero;
                isAttacking = false;
            }
        }
        else
        {
            // Player:
            maxSpeed = Input.GetButton("Fire3") ? runSpeed : walkSpeed;
            isAttacking = Input.GetButton("Fire1");

            speed = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * maxSpeed;
        }
        
        animator.SetBool("isAttacking", isAttacking);

        animator.SetFloat("moveSpeed", speed.magnitude);

        

        if (gameObject.tag == "Player")
        {
            spriteRenderer.flipX = speed.x < 0;
            rbody.velocity = speed;
        }
        else if (speed != Vector3.zero)
        {
            spriteRenderer.flipX = player.transform.position.x < gameObject.transform.position.x;

            rbody.transform.position = speed;
        }
    }
}
