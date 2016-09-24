using UnityEngine;
using System.Collections;

public class ResetPosition : MonoBehaviour {

    Rigidbody2D ballRigidbody;

    // Use this for initialization
    void Start () {
        ballRigidbody = GameObject.Find("Ball").GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.R)) {
            transform.position = new Vector2(-7.04f, 2.98f);
            ballRigidbody.velocity = Vector2.zero;
            //ballRigidbody.angularVelocity = Vector2.zero;
        }

    }
}
