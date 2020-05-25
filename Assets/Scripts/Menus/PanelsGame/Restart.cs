using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour {
    private GameManager gameManager;
    private Button buttonRestart;

    private void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        buttonRestart = GetComponent<Button>();
        buttonRestart.onClick.AddListener(gameManager.Restart);
    }

}
