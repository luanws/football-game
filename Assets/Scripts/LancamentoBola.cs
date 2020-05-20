using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancamentoBola : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float forca = 1000;
    private RotacaoSeta rotacaoSeta;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rotacaoSeta = GetComponent<RotacaoSeta>();
    }

    void Update()
    {
        if (rotacaoSeta.chuteLiberado || Input.GetKeyUp(KeyCode.Space))
        {
            chutar();
        }
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
}
