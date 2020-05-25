using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {
    private Spawner spawner;
    private Rigidbody2D rigidbody2D;
    private KickManager kickManager;
    private GameManager gameManager;

    private void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawner = GetComponent<Spawner>();
        kickManager = GetComponent<KickManager>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        OverflowPositionDeath();
        Suicide();
        // IsStoppedDeath();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Death")) OnDeath("colisão com objeto mortal");
    }

    private void OnDeath(string causeOfDeath) {
        if (!gameManager.win) {
            print("Causa da morte: " + causeOfDeath);
            gameManager.OnDeath();
            spawner.Spawn();
        }
    }

    private void OverflowPositionDeath() {
        float limitLeft = gameManager.limitLeft;
        float limitRight = gameManager.limitRight;
        float x = transform.position.x;

        bool overflowPosition = x < limitLeft || x > limitRight;
        if (overflowPosition) OnDeath("estouro dos limites de posição horizontal");
    }

    private void IsStoppedDeath() {
        if (rigidbody2D.velocity == Vector2.zero && !kickManager.kickControlAllowed) OnDeath("velocidade nula");
    }

    public void Suicide() {
        if (!kickManager.kickControlAllowed && Input.GetMouseButton(0)) OnDeath("suicídio");
    }
}
