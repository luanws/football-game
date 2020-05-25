using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {
    private Spawner spawner;
    private Transform transformLimitLeft;
    private Transform transformLimitRight;
    private Rigidbody2D rigidbody2D;
    private KickManager kickManager;

    private void Start() {
        spawner = GetComponent<Spawner>();
        kickManager = GetComponent<KickManager>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        transformLimitLeft = GameObject.Find("LimitLeft").transform;
        transformLimitRight = GameObject.Find("LimitRight").transform;
    }

    private void Update() {
        OverflowPositionDeath();
        // IsStoppedDeath();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Death")) OnDeath("colisão com objeto mortal");
    }

    private void OnDeath(string causeOfDeath) {
        spawner.Spawn();
        print("Causa da morte: " + causeOfDeath);
    }

    private void OverflowPositionDeath() {
        float limitLeft = transformLimitLeft.position.x;
        float limitRight = transformLimitRight.position.x;
        float x = transform.position.x;

        bool overflowPosition = x < limitLeft || x > limitRight;
        if (overflowPosition) OnDeath("estouro dos limites de posição horizontal");
    }

    private void IsStoppedDeath() {
        if (rigidbody2D.velocity == Vector2.zero && !kickManager.kickControlAllowed) OnDeath("velocidade nula");
    }
}
