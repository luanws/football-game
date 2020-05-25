﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    [SerializeField] private Transform transformLimitLeft;
    [SerializeField] private Transform transformLimitRight;
    [SerializeField] private Text textAttempts;
    [SerializeField] private int attempts;

    public bool spawnAllowed { get { return attempts >= 1; } }
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

    public void OnDeath() {
        if (attempts <= 1) {
            attempts = 0;
            Lose();
        }
        else attempts -= 1;
    }

    public void OnGoal() {
        
    }

    private void Win() {

    }

    private void Lose() {
        print("Game Over");
    }
}
