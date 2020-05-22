using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoFase : MonoBehaviour
{
    public Text textFase;
    public Fase fase {
        get {
            Fase fase = new Fase(
                int.Parse(textFase.text), 
                GetComponent<Button>().interactable
            );
            return fase;
        }
        set {
            textFase.text = value.numero.ToString();
            GetComponent<Button>().interactable = value.desbloqueado;
            textFase.enabled = value.desbloqueado;
        }
    }
}
