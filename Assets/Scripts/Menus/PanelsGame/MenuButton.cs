using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour {
    private GameManager gameManager;
    private Button buttonMenu;

    private void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        buttonMenu = GetComponent<Button>();
        buttonMenu.onClick.AddListener(gameManager.BackToMenu);
    }
}
