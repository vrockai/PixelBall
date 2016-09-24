using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {
    
    private PlayerMove player;
        
    void Start () {
        player = GetComponentInParent<PlayerMove>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.name == "Floor") {

            player.grounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Floor") {
            player.grounded = false;
        }
    }
}
