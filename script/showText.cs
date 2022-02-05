using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class showText : MonoBehaviour
{
    public Text texto;
    // Start is called before the first frame update
    automate mate;
    float currentTime;
    SolveTwoPhases solveTwoPhases;

    void Start() {
        mate = FindObjectOfType<automate>();
        solveTwoPhases = FindObjectOfType<SolveTwoPhases>();
    }

    public void activarTexto() {
        texto.gameObject.SetActive(true);
    }

    public void Mezclar() {
        mate.Mezclar();
    }

    public void Solver() {
        solveTwoPhases.Solver();
    }


    public void desactivarTexto() {
        texto.gameObject.SetActive(false);
    }
}
