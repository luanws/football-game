using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    public GameObject botaoPrefab;
    public Transform botaoTransform;
    public List<Level> levels;

    void Start() {
        // PlayerPrefs.DeleteAll();
        desbloquearFase(1);
        gerarBotoes();
    }

    private void gerarBotoes() {
        foreach (Level level in levels) {
            GameObject botao = Instantiate(botaoPrefab);
            ButtonLevel buttonLevel = botao.GetComponent<ButtonLevel>();

            buttonLevel.level = level;
            botao.transform.SetParent(botaoTransform, false);

            buttonLevel.GetComponent<Button>().onClick.AddListener(level.Start);
        }
    }

    private void desbloquearFase(int numero) {
        Level level = new Level(numero);
        level.Unlock();
        print("Level " + level.number + " desbloqueado");
    }
}
