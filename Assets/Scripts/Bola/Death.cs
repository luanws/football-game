using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {
    private Spawner spawner;
    private Transform transformLimitLeft;
    private Transform transformLimitRight;

    private void Start() {
        spawner = GetComponent<Spawner>();
        transformLimitLeft = GameObject.Find("LimitLeft").transform;
        transformLimitRight = GameObject.Find("LimitRight").transform;
    }

    private void Update() {
        OverflowPosition();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Death")) OnDeath();
    }

    private void OnDeath() {
        spawner.Spawn();
    }

    private void OverflowPosition() {
        float limitLeft = transformLimitLeft.position.x;
        float limitRight = transformLimitRight.position.x;
        float x = transform.position.x;

        bool overflowPosition = x < limitLeft || x > limitRight;
        if (overflowPosition) OnDeath();
    }
}
