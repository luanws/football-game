using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour {
    private GameObject ball;
    private GameManager gameManager;
    private float limitLeft, limitRight;
    private float t = 1;
    [SerializeField] private float velocitySmoothStepCamera = 0.5f;

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
            
            if (transform.position.x != limitLeft && ball.GetComponent<Rigidbody2D>().velocity == Vector2.zero) {
                t -= velocitySmoothStepCamera * Time.deltaTime;
                position.x = Mathf.SmoothStep(limitLeft, position.x, t);
            } else {
                t = 1;
                position.x = ball.transform.position.x;
            }

            position.x = Mathf.Clamp(position.x, limitLeft, limitRight);
            transform.position = position;
        }
    }
}
