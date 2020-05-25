using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour {
    private GameObject ball;
    private GameManager gameManager;

    private void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    private void Update() {
        ball = GameObject.Find("Ball");
        if (ball != null) {
            Vector3 position = transform.position;
            position.x = ball.transform.position.x;
            position.x = Mathf.Clamp(position.x, gameManager.limitLeft, gameManager.limitRight);
            transform.position = position;
        }
    }
}
