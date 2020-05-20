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
    }

    private void posicionarBola()
    {
        gameObject.transform.position = posicaoInicial.position;
    }

    private void posicionarSeta()
    {
        setaImage.rectTransform.position = gameObject.transform.position;
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
                rotacao = Vector2.Angle(new Vector2(mouse.x, 0), mouse);
            }
            else if (mouse.x > 0 && mouse.y < 0)
            {
                rotacao = 180 - Vector2.Angle(new Vector2(mouse.x, 0), mouse);
            }
            else if (mouse.x > 0 && mouse.y > 0)
            {
                rotacao = 180 + Vector2.Angle(new Vector2(mouse.x, 0), mouse);
            }
            else if (mouse.x < 0 && mouse.y > 0)
            {
                rotacao = -Vector2.Angle(new Vector2(mouse.x, 0), mouse);
            }
        }
    }

    private void OnMouseDown()
    {
        posicionarSeta();
        rotacaoLiberada = true;
    }

    private void OnMouseUp()
    {
        rotacaoLiberada = false;
        chuteLiberado = true;
    }
}

