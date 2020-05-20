using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotacaoSeta : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform posicaoInicial;
    [SerializeField] private Image setaImage;
    public float velocidadeRotacao = 2.5f;
    public float rotacao;
    public bool rotacaoLiberada = false;
    public bool chuteLiberado = false;

    private void Start()
    {
        posicionarBola();
        posicionarSeta();
    }

    private void Update()
    {
        rotacionarSeta();
        inputRotacao();
        // limitarRotacao();
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
        if (rotacaoLiberada)
        {
            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse -= (Vector2)gameObject.transform.position;
            if (mouse.x <= 0 && mouse.y <= 0)
            {
                float angulo = Vector2.Angle(new Vector2(mouse.x, 0), mouse);
                rotacao = angulo;
            }
        }
    }

    private void limitarRotacao()
    {
        if (rotacao > 90)
        {
            rotacao = 90;
        }
        else if (rotacao < 0)
        {
            rotacao = 0;
        }
    }

    private void OnMouseDown()
    {
        rotacaoLiberada = true;
    }

    private void OnMouseUp()
    {
        rotacaoLiberada = false;
        chuteLiberado = true;
    }
}

