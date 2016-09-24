using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public bool grounded;
    private PlayerMove player;

    // Use this for initialization
    void Start () {
        player = GetComponentInParent<PlayerMove>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {        
        Debug.Log("OnTriggerEnter2D " + other.tag);
        if (other.tag == "Ball")
        {
            player.canShoot = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("OnTriggerExit2D" + other);
        if (other.tag == "Ball")
        {
            player.canShoot = false;
        }
    }
}
