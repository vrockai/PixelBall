using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TouchGround : MonoBehaviour {

    private GameManager gameManager;

    void Start() {
        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");
        if (gameManagerObject != null) {
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }
        if (gameManager == null) {
            Debug.Log("Cannot find 'GameManager' script");
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "LeftColliderFloor") {
            gameManager.updateScore(false, 1);
        } else if (other.name == "RightColliderFloor") {
            gameManager.updateScore(true, 1);
        }
    }
}
