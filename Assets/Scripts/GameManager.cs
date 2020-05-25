using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    [SerializeField] private Transform transformLimitLeft;
    [SerializeField] private Transform transformLimitRight;

    public float limitLeft { get { return transformLimitLeft.position.x; } }
    public float limitRight { get { return transformLimitRight.position.x; } }

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
}
