using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tnt : MonoBehaviour {
    [SerializeField] 
    private GameObject explosaoPrefab;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Instantiate(explosaoPrefab, transform.position, Quaternion.identity);
        }
    }
}
