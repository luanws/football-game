using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    private GameManager gameManager;
    private Rigidbody2D rigidbody2D;
    private KickManager kickManager;
    private Vector2 positionSpawn;

    private void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        kickManager = GetComponent<KickManager>();
        positionSpawn = transform.position;
    }

    public void Spawn() {
        if (gameManager.spawnAllowed) {
            kickManager.kickControlAllowed = true;
            GameObject ball = Instantiate(gameObject, positionSpawn, Quaternion.identity);
            ball.name = "Ball";
        }
        Destroy(gameObject);
    }
}
