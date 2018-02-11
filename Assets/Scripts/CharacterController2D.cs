using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour {
   
    //Rigid body controller
    public Rigidbody2D rBody;

    //The maximum horizontal speed of the player;
    public float maxHorSpeed;

    //The jumping force applied to the character when jumping
    public float jumpingForce;

    //max distance to floor for jumping
    public float rayCastDistance;

    //Are we grounded
    public bool isGrounded;

    //how far we must move
    private float move;

    // Use this for initialization
    void Start () {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        //We do the normal keyboard and mouse operations here. 
        move = Input.GetAxis("Horizontal");

        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.down, rayCastDistance);

        foreach (RaycastHit2D rh in hit)
        {
            if (rh.collider.gameObject.name != "PlayerObject")
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
                continue;
            }
        }
    }

    void FixedUpdate() {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rBody.AddForce(Vector2.up * jumpingForce, ForceMode2D.Impulse);
        }

        rBody.velocity = new Vector2(move * maxHorSpeed, rBody.velocity.y);
    }

}
