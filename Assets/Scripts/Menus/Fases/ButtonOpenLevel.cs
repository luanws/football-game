﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonOpenLevel : MonoBehaviour {
    public Button button;
    void Start() {
        button.onClick.AddListener(() => {
            SceneManager.LoadScene("Scenes/Fases");
        });
    }
}
