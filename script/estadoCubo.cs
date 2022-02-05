using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class estadoCubo : MonoBehaviour
{
    
    public List<GameObject> top = new List<GameObject>();
    public List<GameObject> bot = new List<GameObject>();
    public List<GameObject> left = new List<GameObject>();
    public List<GameObject> right = new List<GameObject>();
    public List<GameObject> front = new List<GameObject>();
    public List<GameObject> back = new List<GameObject>();

    public bool hasRotate = false;
    public static bool autoRotating = false;
    public static bool started = false;

    public void PickUp(List<GameObject> cubeSide) {
        foreach (GameObject face in cubeSide) {
            if (face != cubeSide[4]) {
                face.transform.parent.transform.parent = cubeSide[4].transform.parent;
            }
        }
        //Debug.Log(cubeSide.Count);
        
    }

    public void PutDown(List<GameObject> piezas, Transform pivot) {
        
        
        foreach (GameObject pieza in piezas) {
            if (pieza != piezas[4]) {
                pieza.transform.parent.transform.parent = pivot;
            }
        }        
        
    }

    string GetSideString(List<GameObject> side) {
        string sideString = "";
        foreach (GameObject face in side) {
            if (face.name == "bottom") sideString += "D";
            else sideString += face.name[0];
            
            
        }
        return sideString;
    }

    public string GetStateString() {
        string stateString = "";
        stateString += GetSideString(top);
        stateString += GetSideString(right);
        stateString += GetSideString(front);
        stateString += GetSideString(bot);
        stateString += GetSideString(left);
        stateString += GetSideString(back);
        return stateString;
    }
}
