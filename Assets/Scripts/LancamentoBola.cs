using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LancamentoBola : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float forca = 1000;
    private RotacaoSeta rotacaoSeta;
    [SerializeField] private Image setaVerde;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rotacaoSeta = GetComponent<RotacaoSeta>();
    }

    void Update()
    {
        if (rotacaoSeta.chuteLiberado)
        {
            chutar();
        }
        controlarForca();
    }

    private Vector2 polar(float raio, float angulo)
    {
        float x = raio * Mathf.Cos(angulo * Mathf.Deg2Rad);
        float y = raio * Mathf.Sin(angulo * Mathf.Deg2Rad);
        return new Vector2(x, y);
    }

    private void chutar()
    {
        rigidbody2D.AddForce(polar(forca, rotacaoSeta.rotacao));
        rotacaoSeta.chuteLiberado = false;
    }

    private void controlarForca()
    {
        if (rotacaoSeta.rotacaoLiberada)
        {
            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float distancia = Vector2.Distance(mouse, transform.position);
            if (distancia > 0)
            {
                setaVerde.fillAmount = distancia / 2;
                forca = setaVerde.fillAmount * 1000;
            }
        }
    }

    private void OnMouseDown()
    {
        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.Sleep();
    }
}
