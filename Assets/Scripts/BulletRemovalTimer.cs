using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRemovalTimer : MonoBehaviour {
    void Start()
    {
        Destroy(this.gameObject, 7);    
    }
}
