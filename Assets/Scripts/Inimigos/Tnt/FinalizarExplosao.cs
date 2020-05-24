using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalizarExplosao : MonoBehaviour {
    [SerializeField]
    private float tempoExplosao = 0.5f;
    void Update() {
        StartCoroutine(destruirTnt());
    }
    
    private IEnumerator destruirTnt() {
        yield return new WaitForSeconds(tempoExplosao);
        Destroy(gameObject);
    }
}
