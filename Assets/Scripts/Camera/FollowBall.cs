using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour {
    private GameObject ball;
    private GameManager gameManager;
    private float limitLeft, limitRight;

    private void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        float screenHeight = Camera.main.orthographicSize * 2;
        float screenWidth = screenHeight / Screen.height * Screen.width;
        limitLeft = gameManager.limitLeft + (screenWidth / 2);
        limitRight = gameManager.limitRight - (screenWidth / 2);
    }

    private void Update() {
        ball = GameObject.Find("Ball");
        if (ball != null) {
            Vector3 position = transform.position;
            position.x = ball.transform.position.x;
            position.x = Mathf.Clamp(position.x, limitLeft, limitRight);
            transform.position = position;
        }
    }
}
