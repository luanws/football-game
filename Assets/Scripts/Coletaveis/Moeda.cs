using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour {
    [SerializeField] private int valor = 1;
    [SerializeField] private AudioClip audioClipColetaMoeda;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Pontuacao.instance.AdicionarMoedas(valor);
            Sons.instance.Play(audioClipColetaMoeda);
            Destroy(gameObject);
        }
    }
}
