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

    private float move;

    //if we are on mobile, we need to check to see if multiple touch is supported
    //if not, we are going to have a problem
#if (UNITY_IOS || UNITY_ANDROID)
    public bool multipleTouchSupported;
    public bool touchPressureSupported;
#endif

    // Use this for initialization
    void Start () {
        rBody = GetComponent<Rigidbody2D>();

#if (UNITY_IOS || UNITY_ANDROID)
        multipleTouchSupported = Input.multiTouchEnabled;
        touchPressureSupported = Input.touchPressureSupported;
#endif
    }

    // Update is called once per frame
    void Update() {
#if (UNITY_IOS||UNITY_ANDROID)
        foreach (Touch t in Input.touches)
        {
            if (t.phase == TouchPhase.Began)
            {
                print("touch began: ");
                print(t.position);
            }
            else if (t.phase == TouchPhase.Ended)
            {
                print("touch ended: ");
                print(t.position);
            }
            else if (t.phase == TouchPhase.Moved)
            {
                print("touch moved: ");
                print(t.position);
            }
            else if (t.phase == TouchPhase.Stationary)
            {
                print("touch stationary: ");
                print(t.position);
            }
        }
#elif (UNITY_STANDALONE)
        //We do the normal keyboard and mouse operations here. 
        move = Input.GetAxis("Horizontal");
#endif

        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.down, rayCastDistance);
        Debug.DrawRay(transform.position, Vector3.down, Color.white);

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
