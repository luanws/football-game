using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KickManager : MonoBehaviour {
    [SerializeField] private Image imagemArrow;
    [SerializeField] private Image imageArrowGreen;
    [SerializeField] private AudioClip audioClipKick;
    private Rigidbody2D rigidbody2D;
    private float rotation;
    private bool rotationAllowed = false;
    private bool kickAllowed = false;
    private float forceKick = 1000;

    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();

        imagemArrow.enabled = false;
        imageArrowGreen.enabled = false;
    }

    private void Update() {
        RotateArrow();
        InputRotation();

        if (kickAllowed) {
            Kick();
        }
        ForceControl();
    }

    private void OnMouseDown() {
        imagemArrow.enabled = true;
        imageArrowGreen.enabled = true;
        rotationAllowed = true;
        rigidbody2D.Sleep();
    }

    private void OnMouseUp() {
        imagemArrow.enabled = false;
        imageArrowGreen.enabled = false;
        rotationAllowed = false;
        kickAllowed = true;
    }
    
    private void RotateArrow() {
        imagemArrow.rectTransform.eulerAngles = new Vector3(0, 0, rotation);
    }

    private void InputRotation() {
        if (rotationAllowed) {
            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse -= (Vector2)gameObject.transform.position;
            
            if (mouse.x <= 0 && mouse.y <= 0) {
                rotation = Vector2.Angle(new Vector2(mouse.x, 0), mouse);
            }
            else if (mouse.x > 0 && mouse.y < 0) {
                rotation = 180 - Vector2.Angle(new Vector2(mouse.x, 0), mouse);
            }
            else if (mouse.x > 0 && mouse.y > 0) {
                rotation = 180 + Vector2.Angle(new Vector2(mouse.x, 0), mouse);
            }
            else if (mouse.x < 0 && mouse.y > 0) {
                rotation = -Vector2.Angle(new Vector2(mouse.x, 0), mouse);
            }
        }
    }

    private void Kick() {
        float x = forceKick * Mathf.Cos(rotation * Mathf.Deg2Rad);
        float y = forceKick * Mathf.Sin(rotation * Mathf.Deg2Rad);
        rigidbody2D.AddForce(new Vector2(x, y));
        kickAllowed = false;
        Sons.instance.Play(audioClipKick);
    }

    private void ForceControl() {
        if (rotationAllowed) {
            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float distancia = Vector2.Distance(mouse, transform.position);
            if (distancia > 0) {
                imageArrowGreen.fillAmount = distancia / 2;
                forceKick = imageArrowGreen.fillAmount * 1000;
            }
        }
    }
}
