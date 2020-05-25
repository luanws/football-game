using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartLevelButton : MonoBehaviour {
    private GameManager gameManager;
    private Button buttonRestart;

    private void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        buttonRestart = GetComponent<Button>();
        print(buttonRestart);
        buttonRestart.onClick.AddListener(gameManager.RestartLevel);
    }
}
