using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour {
    private GameManager gameManager;
    private Button buttonResume;
    [SerializeField] private GameObject panelPause;

    private void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        buttonResume = GetComponent<Button>();
        buttonResume.onClick.AddListener(() => {
            panelPause.SetActive(false);
            gameManager.Resume();
        });
    }
}
