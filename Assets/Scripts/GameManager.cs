using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
    
    private int leftScore = 0;
    private int rightScore = 0;

    public Text leftScoreText;
    public Text rightScoreText;

    private bool isNewRound = true;
    
    // Use this for initialization
    void Start () {
        leftScoreText.text = leftScore + "";
        rightScoreText.text = rightScore + "";
    }

    public void updateScore (bool side, int increment) {
        if (!isNewRound) {
            return;
        }

        isNewRound = false;

        if (side) {
            leftScore += increment;
            leftScoreText.text = leftScore + "";
        }else {
            rightScore += increment;
            rightScoreText.text = rightScore + "";
        }
    }

    public void startNewRound() {
        isNewRound = true;
    }
}
