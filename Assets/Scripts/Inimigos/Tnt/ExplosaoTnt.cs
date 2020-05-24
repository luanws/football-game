using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosaoTnt : MonoBehaviour {
    [SerializeField] 
    private GameObject explosaoPrefab;

    private void OnCollisionEnter2D(Collision2D other) {
        if (!other.gameObject.CompareTag("Cenario")) {
            Instantiate(explosaoPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
