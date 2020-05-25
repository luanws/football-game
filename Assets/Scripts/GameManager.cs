using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    [SerializeField] private Transform transformLimitLeft;
    [SerializeField] private Transform transformLimitRight;
    [SerializeField] private Text textAttempts;
    [SerializeField] private int attempts;

    public float limitLeft { get { return transformLimitLeft.position.x; } }
    public float limitRight { get { return transformLimitRight.position.x; } }

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    private void Update() {
        textAttempts.text = attempts.ToString();
    }

    public void DecrementAttempt() {
        if (attempts <= 1) {
            attempts = 0;
            GameOver();
        }
        else attempts -= 1;
    }

    private void GameOver() {
        print("Game Over");
    }
}
