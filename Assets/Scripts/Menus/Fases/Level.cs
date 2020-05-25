using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Level {
    public int numero;
    private const string CHAVE_FASE = "fase_desbloqueada_";
    public bool desbloqueada {
        get { 
            return bool.Parse(PlayerPrefs.GetString(CHAVE_FASE + numero, "false"));
        }
    }
    public Level(int numero) {
        this.numero = numero;
    }
    public void bloquear() {
        PlayerPrefs.SetString(CHAVE_FASE + numero, false.ToString());
    }
    public void desbloquear() {
        PlayerPrefs.SetString(CHAVE_FASE + numero, true.ToString());
    }
    public void iniciar() {
        SceneManager.LoadScene("Scenes/Fases/" + numero.ToString());
    }
}