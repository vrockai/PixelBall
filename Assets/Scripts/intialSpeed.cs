using UnityEngine;
using System.Collections;

public class intialSpeed : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Rigidbody2D myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.AddForce(new Vector2(3.5f,0.5f), ForceMode2D.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
