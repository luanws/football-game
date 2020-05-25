using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] private Transform transformLimitLeft;
    [SerializeField] private Transform transformLimitRight;
    private Rigidbody2D rigidbody2D;
    private KickManager kickManager;
    private Animator animator;
    private Vector2 positionSpawn;

    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        kickManager = GetComponent<KickManager>();
        animator = GetComponent<Animator>();
        positionSpawn = transform.position;
    }

    private void Update() {
        if (CheckDeath()) Spawn();
    }

    private void Spawn() {
        rigidbody2D.Sleep();
        transform.position = positionSpawn;
        kickManager.kickControlAllowed = true;
    }

    private bool CheckDeath() {
        float limitLeft = transformLimitLeft.position.x;
        float limitRight = transformLimitRight.position.x;
        float x = transform.position.x;

        return x < limitLeft || x > limitRight;
    }
}
