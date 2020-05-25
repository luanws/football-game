using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelsButtons : MonoBehaviour {
    private GameManager gameManager;
    [SerializeField] private Button[] buttonsMenu;
    [SerializeField] private Button[] buttonsNextLevel;
    [SerializeField] private Button[] buttonsPause;
    [SerializeField] private Button[] buttonsRestartLevel;

    private void Start() {
        print("Start");
        gameManager = GetComponent<GameManager>();

        foreach (Button button in buttonsNextLevel) NextLevel(button);
        foreach (Button button in buttonsPause) Pause(button);
        foreach (Button button in buttonsRestartLevel) RestartLevel(button);
    }
    private void NextLevel(Button button) {
        button.onClick.AddListener(gameManager.NextLevel);
    }
    private void RestartLevel(Button button) {
        button.onClick.AddListener(gameManager.RestartLevel);
    }
    private void Pause(Button button) {
        button.onClick.AddListener(gameManager.Pause);
    }
}
