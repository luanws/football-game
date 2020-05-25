using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    public GameObject botaoPrefab;
    public Transform botaoTransform;
    public List<Level> fases;

    void Start() {
        // PlayerPrefs.DeleteAll();
        desbloquearFase(1);
        gerarBotoes();
    }

    private void gerarBotoes() {
        foreach (Level fase in fases) {
            GameObject botao = Instantiate(botaoPrefab);
            ButtonLevel botaoFase = botao.GetComponent<ButtonLevel>();

            botaoFase.fase = fase;
            botao.transform.SetParent(botaoTransform, false);

            botaoFase.GetComponent<Button>().onClick.AddListener(() => {
                desbloquearFase(fase.numero + 1);
                fase.iniciar();
            });
        }
    }

    private void desbloquearFase(int numero) {
        Level fase = new Level(numero);
        fase.desbloquear();
    }
}
