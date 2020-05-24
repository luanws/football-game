using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExibirPontuacao : MonoBehaviour {
    private Text text;
    private void Start() {
        text = GetComponent<Text>();
    }
    private void Update() {
        text.text = Pontuacao.instance.moedas.ToString();
    }
}
