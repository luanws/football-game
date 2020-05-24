using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotacaoSeta : MonoBehaviour {
    [SerializeField] private Image setaImagem;
    [SerializeField] private Image setaImagemVerde;
    public float rotacao;
    public bool rotacaoLiberada = false;
    public bool chuteLiberado = false;

    private void Start() {
        setaImagem.enabled = false;
        setaImagemVerde.enabled = false;
    }

    private void Update() {
        rotacionarSeta();
        inputRotacao();
    }

    private void rotacionarSeta() {
        setaImagem.rectTransform.eulerAngles = new Vector3(0, 0, rotacao);
    }

    private void inputRotacao() {
        if (rotacaoLiberada) {
            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse -= (Vector2)gameObject.transform.position;
            
            if (mouse.x <= 0 && mouse.y <= 0) {
                rotacao = Vector2.Angle(new Vector2(mouse.x, 0), mouse);
            }
            else if (mouse.x > 0 && mouse.y < 0) {
                rotacao = 180 - Vector2.Angle(new Vector2(mouse.x, 0), mouse);
            }
            else if (mouse.x > 0 && mouse.y > 0) {
                rotacao = 180 + Vector2.Angle(new Vector2(mouse.x, 0), mouse);
            }
            else if (mouse.x < 0 && mouse.y > 0) {
                rotacao = -Vector2.Angle(new Vector2(mouse.x, 0), mouse);
            }
        }
    }

    private void OnMouseDown() {
        setaImagem.enabled = true;
        setaImagemVerde.enabled = true;
        rotacaoLiberada = true;
    }

    private void OnMouseUp() {
        setaImagem.enabled = false;
        setaImagemVerde.enabled = false;
        rotacaoLiberada = false;
        chuteLiberado = true;
    }
}

