using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontuacao : MonoBehaviour
{
    private static Pontuacao _instance;
    public static Pontuacao instance {
        get {
            if (_instance == null) {
                _instance = new Pontuacao();
            }
            return _instance;
        }
    }
    public int moedas {
        get {
            return PlayerPrefs.GetInt("moedas", 100);
        }
        set {
            PlayerPrefs.SetInt("moedas", value);
        }
    }

    public void AdicionarMoedas(int novasMoedas) {
        moedas += novasMoedas;
    }

    public void RemoverMoedas(int perdaMoedas) {
        moedas -= perdaMoedas;
    }
}
