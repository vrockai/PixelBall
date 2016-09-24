using UnityEngine;
using System.Collections;

public class ShootAvailable : MonoBehaviour {

    private PlayerMove player;
    private Collider2D ballCollider;
    private Collider2D playerCollider;

    // Use this for initialization
    void Start() {
        player = GetComponentInParent<PlayerMove>();
        playerCollider = player.GetComponent<Collider2D>();
        ballCollider = GameObject.Find("Ball").GetComponent<CircleCollider2D>();

        Debug.Log(playerCollider);
        Debug.Log(ballCollider);
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ball") {
            player.canShoot = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Ball") {
            Physics2D.IgnoreCollision(playerCollider, ballCollider, false);
            Debug.Log("Som out");
            player.canShoot = false;
        }
    }
}
