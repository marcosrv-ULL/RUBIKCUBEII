using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class selectCara : MonoBehaviour
{
    estadoCubo cubestate;
    leerCubo readCube;
    public GameObject cabeza;
    public GvrReticlePointer puntero;
    Vector3 firstpos;
    Vector3 secondpos;
    public bool dragging;

    int mascaraCapa = 1 << 8; 
    // Start is called before the first frame update
    void Start()
    {
        readCube = FindObjectOfType<leerCubo>();
        cubestate = FindObjectOfType<estadoCubo>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void getPointerDown() {
        if(!estadoCubo.autoRotating) {
            firstpos = puntero.coordenateReticle;
            Debug.Log(firstpos.x + " " + firstpos.y + " " + firstpos.z + " ");
            Vector3 lineStart = cabeza.transform.position;
            Vector3 lineEnd = lineStart + 400.0f * cabeza.transform.forward;
            readCube.LeerEstado();
            RaycastHit hit;
            cubestate.hasRotate = false;
            Ray ray = new Ray(lineStart, lineEnd);
            if(Physics.Raycast(ray, out hit, 100.0f, mascaraCapa)) {
                GameObject face = hit.collider.gameObject;
                Debug.Log("Hit");
                List<List<GameObject>> cubeSides = new List<List<GameObject>>() {
                    cubestate.top,
                    cubestate.bot,
                    cubestate.right,
                    cubestate.left,
                    cubestate.back,
                    cubestate.front
                };

                foreach (List<GameObject> cubeSide in cubeSides) {
                    if (cubeSide.Contains(face)) {
                        cubestate.PickUp(cubeSide);
                        cubeSide[4].transform.parent.GetComponent<pivotRotation>().Rotate(cubeSide);
                    }
                }
            }
        }
        
    }

    public void getPointerUp() {
        if(!estadoCubo.autoRotating) {
            secondpos = puntero.coordenateReticle;
            controllercommand.stopDragging();
        }
    }
}

public static class controllercommand {
    public static Action stopDragging;
}
