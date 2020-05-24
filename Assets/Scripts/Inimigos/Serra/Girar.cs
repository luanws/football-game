using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girar : MonoBehaviour
{
    [SerializeField] private float velocidade = 0;

    void Start() {
        
    }

    void Update() {
        transform.Rotate(new Vector3(0, 0, velocidade * Time.deltaTime));
    }
}
