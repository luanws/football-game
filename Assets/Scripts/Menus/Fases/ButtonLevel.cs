using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevel : MonoBehaviour
{
    public Text textFase;
    public Level fase {
        get {
            Level fase = new Level(int.Parse(textFase.text));
            return fase;
        }
        set {
            textFase.text = value.numero.ToString();
            GetComponent<Button>().interactable = value.desbloqueada;
            textFase.enabled = value.desbloqueada;
        }
    }
}
