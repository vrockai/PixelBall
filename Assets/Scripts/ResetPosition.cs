using UnityEngine;
using System.Collections;

public class ResetPosition : MonoBehaviour {

    Rigidbody2D ballRigidbody;
    private GameManager gameManager;

    // Use this for initialization
    void Start () {
        ballRigidbody = GameObject.Find("Ball").GetComponent<Rigidbody2D>();

        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");
        if (gameManagerObject != null) {
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }
        if (gameManager == null) {
            Debug.Log("Cannot find 'GameManager' script");
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.R)) {
            transform.position = new Vector2(-7.04f, 2.98f);
            ballRigidbody.velocity = Vector2.zero;
            //ballRigidbody.angularVelocity = Vector2.zero;
            gameManager.startNewRound();
        }

    }
}
