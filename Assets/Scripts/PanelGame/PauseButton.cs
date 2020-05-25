using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {
    private GameManager gameManager;
    private Button buttonPause;
    private void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        buttonPause = GetComponent<Button>();
        buttonPause.onClick.AddListener(gameManager.Pause);
    }
}
