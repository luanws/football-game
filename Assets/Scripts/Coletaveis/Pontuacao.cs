﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontuacao : MonoBehaviour
{
    public static Pontuacao instance;
    public int moedas {
        get {
            return PlayerPrefs.GetInt("moedas", 100);
        }
        set {
            PlayerPrefs.SetInt("moedas", value);
        }
    }

    void Awake() {
        if(instance == null) {
            instance = this;
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