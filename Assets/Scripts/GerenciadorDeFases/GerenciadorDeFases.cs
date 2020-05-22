using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GerenciadorDeFases : MonoBehaviour {
    public GameObject botaoPrefab;
    public Transform botaoTransform;
    public List<Fase> fases;

    void Start() {
        gerarBotoes();
    }

    private void gerarBotoes() {
        foreach (Fase fase in fases) {
            GameObject botao = Instantiate(botaoPrefab);
            BotaoFase botaoFase = botao.GetComponent<BotaoFase>();

            if (bool.Parse(PlayerPrefs.GetString("fase_desbloqueada_" + fase.numero, "false"))) {
                fase.desbloquear();
            }
            fase.desbloquear();

            botaoFase.fase = fase;
            botao.transform.SetParent(botaoTransform, false);

            botaoFase.GetComponent<Button>().onClick.AddListener(() => {
                iniciarFase(fase);
            });
        }
    }

    private void iniciarFase(Fase fase) {
        SceneManager.LoadScene("Scenes/Fases/" + fase.numero.ToString());
    }
}
