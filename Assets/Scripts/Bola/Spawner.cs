using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    private Rigidbody2D rigidbody2D;
    private KickManager kickManager;
    private Vector2 positionSpawn;

    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        kickManager = GetComponent<KickManager>();
        positionSpawn = transform.position;
    }

    public void Spawn() {
        kickManager.kickControlAllowed = true;
        GameObject ball = Instantiate(gameObject, positionSpawn, Quaternion.identity);
        ball.name = "Ball";
        Destroy(gameObject);
    }
}
