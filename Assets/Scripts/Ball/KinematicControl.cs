using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicControl : MonoBehaviour {
    private Rigidbody2D rigidbody2D;
    
    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Kinematic() {
        rigidbody2D.isKinematic = true;
    }

    public void RemoveKinematic() {
        rigidbody2D.isKinematic = false;
    }
}
