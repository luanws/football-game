using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorPontuacao : MonoBehaviour
{
    public static GerenciadorPontuacao instancia;
    public int moedas {
        get {
            return PlayerPrefs.GetInt("moedas", 100);
        }
        set {
            PlayerPrefs.SetInt("moedas", value);
        }
    }

    void Awake() {
        if(instancia == null) {
            instancia = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void adicionarMoedas(int novasMoedas) {
        moedas += novasMoedas;
    }

    public void removerMoedas(int perdaMoedas) {
        moedas -= perdaMoedas;
    }
}
