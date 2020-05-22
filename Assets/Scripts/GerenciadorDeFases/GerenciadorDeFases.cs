using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorDeFases : MonoBehaviour {
    public GameObject botaoPrefab;
    public Transform botaoTransform;
    public List<Fase> fases;

    void Start() {
        // PlayerPrefs.DeleteAll();
        desbloquearFase(1);
        gerarBotoes();
    }

    private void gerarBotoes() {
        foreach (Fase fase in fases) {
            GameObject botao = Instantiate(botaoPrefab);
            BotaoFase botaoFase = botao.GetComponent<BotaoFase>();

            botaoFase.fase = fase;
            botao.transform.SetParent(botaoTransform, false);

            botaoFase.GetComponent<Button>().onClick.AddListener(() => {
                desbloquearFase(fase.numero + 1);
                fase.iniciar();
            });
        }
    }

    private void desbloquearFase(int numero) {
        Fase fase = new Fase(numero);
        fase.desbloquear();
    }
}
