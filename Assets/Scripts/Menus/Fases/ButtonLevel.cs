using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevel : MonoBehaviour
{
    public Text textLevel;
    public Level level {
        get {
            Level level = new Level(int.Parse(textLevel.text));
            return level;
        }
        set {
            textLevel.text = value.number.ToString();
            GetComponent<Button>().interactable = value.unlocked;
            textLevel.enabled = value.unlocked;
        }
    }
}
