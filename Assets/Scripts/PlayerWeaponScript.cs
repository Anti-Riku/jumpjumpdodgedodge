using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponScript : MonoBehaviour {

    public GameObject projectile;
    public bool left;

	// Use this for initialization
	void Start () {
        left = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") > 0)
        {
            left = false;
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            left = true;
        }


		if(Input.GetButtonDown("Fire1"))
        {
            GameObject obj = (GameObject)Instantiate(projectile, new Vector3(transform.position.x, transform.position.y+0.11f, 0), transform.rotation);
            if(left)
            {
                obj.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
                obj.GetComponent<Rigidbody2D>().isKinematic = false;
            }
            else
            {
                obj.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
                obj.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
	}
}
