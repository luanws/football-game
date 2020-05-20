using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotacaoSeta : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform posicaoInicial;
    [SerializeField] private Image setaImage;
    public float rotacao;

    private void Start()
    {
        posicionarBola();
        posicionarSeta();
    }

    private void Update()
    {
        rotacionarSeta();
        inputRotacao();
    }

    private void posicionarBola()
    {
        gameObject.transform.position = posicaoInicial.position;
    }

    private void posicionarSeta()
    {
        setaImage.rectTransform.position = posicaoInicial.position;
    }

    private void rotacionarSeta()
    {
        setaImage.rectTransform.eulerAngles = new Vector3(0, 0, rotacao);
    }

    private void inputRotacao()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rotacao += 2.5f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rotacao -= 2.5f;
        }
    }
}

