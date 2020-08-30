using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public Rigidbody2D rb; //the rigid body connected to the white blood cell
    Vector2 movement; //the direction the player is inputting for movement
    public float moveSpeed; //the speed of the white blood cell's movement
    bool isDashing = false;
    public float dashModifier;  //the amount dashing speeds up movement
    public float dashDuration; //how long the speed boost lasts
    public float dashCooldown; //how long player has to wait before dashing again

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!isDashing)  //keeps player from activating a dash while already dashing
                StartCoroutine(DashForward());
        }
    }

    IEnumerator DashForward()
    {
        isDashing = true;
        float oldSpeed = moveSpeed; //stores old speed to return to after dash
        moveSpeed = moveSpeed * dashModifier;

        yield return new WaitForSeconds(dashDuration);

        moveSpeed = oldSpeed;

        yield return new WaitForSeconds(dashCooldown);
        isDashing = false;

        yield break;
    }

    void FixedUpdate()
    {       
        rb.velocity = movement * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            if (isDashing) //only able to destroy enemies while dashing
            {
                Destroy(other.gameObject);
            }
        }
    }
}
