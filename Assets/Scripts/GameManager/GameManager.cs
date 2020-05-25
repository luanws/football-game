using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] private Transform transformLimitLeft;
    [SerializeField] private Transform transformLimitRight;
    [SerializeField] private Text textAttempts;
    [SerializeField] private int attempts = 3;
    [SerializeField] private GameObject panelWin;
    [SerializeField] private GameObject panelLose;
    [SerializeField] private GameObject panelPause;
    private bool _win = false;
    
    public bool win { get { return _win; } }
    public bool spawnAllowed { get { return attempts >= 1 && !_win; } }
    public float limitLeft { get { return transformLimitLeft.position.x; } }
    public float limitRight { get { return transformLimitRight.position.x; } }

    private void Update() {
        textAttempts.text = attempts.ToString();
    }

    public void OnDeath() {
        if (attempts <= 1) {
            attempts = 0;
            Lose();
        }
        else attempts -= 1;
    }

    public void OnGoal() {
        _win = true;
        Win();
    }

    private void Win() {
        panelWin.SetActive(true);
    }

    private void Lose() {
        if (!_win) {
            panelLose.SetActive(true);
        }
    }

    public void Pause() {
        Time.timeScale = 0;
        panelPause.SetActive(true);
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel() {
        int level = int.Parse(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene((level + 1).ToString());
    }
}
