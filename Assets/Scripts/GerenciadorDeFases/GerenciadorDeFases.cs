using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeFases : MonoBehaviour
{
    public GameObject botaoPrefab;
    public Transform botaoTransform;
    public List<Fase> fases;

    void Start()
    {
        gerarBotoes();
    }

    private void gerarBotoes()
    {
        foreach (Fase fase in fases)
        {
            GameObject botao = Instantiate(botaoPrefab);
            BotaoFase botaoFase = botao.GetComponent<BotaoFase>();
            botaoFase.fase = fase;

            botao.transform.SetParent(botaoTransform, false);
        }
    }
}
