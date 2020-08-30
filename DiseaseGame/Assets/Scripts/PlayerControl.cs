using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public Rigidbody2D rb; //the rigid body connected to the white blood cell
    Vector2 movement; //the direction the player is inputting for movement
    public float moveSpeed; //the speed of the white blood cell's movement


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        rb.velocity = movement * moveSpeed;
    }
}
