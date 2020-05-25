using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Level {
    public int number;
    private const string KEY_LEVEL = "fase_desbloqueada_";
    public bool unlocked {
        get { 
            return bool.Parse(PlayerPrefs.GetString(KEY_LEVEL + number, "false"));
        }
    }
    public Level(int numero) {
        this.number = numero;
    }
    public void Lock() {
        PlayerPrefs.SetString(KEY_LEVEL + number, false.ToString());
    }
    public void Unlock() {
        PlayerPrefs.SetString(KEY_LEVEL + number, true.ToString());
    }
    public void UnlockNext() {
        PlayerPrefs.SetString(KEY_LEVEL + (number + 1), true.ToString());
    }
    public void StartNext() {
        SceneManager.LoadScene("Scenes/Fases/" + (number + 1));
    }
    public void Start() {
        SceneManager.LoadScene("Scenes/Fases/" + number);
    }
}