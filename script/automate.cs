using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class automate : MonoBehaviour
{
    public static List<string> listaMovimientos = new List<string>() {};
    private readonly List<string> Movimientos = new List<string>() {
        "T", "B", "D", "R", "L", "F",
        "T'", "B'", "D'", "R'", "L'", "F'",
        "T2", "B2", "D2", "R2", "L2", "F2" 
    };
    private estadoCubo cs;
    private leerCubo rc;
    // Start is called before the first frame update
    void Start()
    {
        cs = FindObjectOfType<estadoCubo>();
        rc = FindObjectOfType<leerCubo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (listaMovimientos.Count > 0 && !estadoCubo.autoRotating && estadoCubo.started) {
            DoMove(listaMovimientos[0]);
            listaMovimientos.Remove(listaMovimientos[0]);
            
        }
    }

    public void Mezclar() {
        //List<string> moves = new List<string>();
        int numeropermutaciones = Random.Range(10, 30);
        
        for (int i = 0; i < numeropermutaciones; i++) {
            int movimiento_random = Random.Range(0, Movimientos.Count);
            listaMovimientos.Add(Movimientos[movimiento_random]);
        }
    }

    void DoMove(string move) {
        rc.LeerEstado();
        estadoCubo.autoRotating = true;
        if(move == "T'") {
            RotateSide(cs.top, -90);
        } else if (move == "T") {
            RotateSide(cs.top, 90);
        } else if (move == "T2") {
            RotateSide(cs.top, -180);
        } else if (move == "B") {
            RotateSide(cs.back, 90);
        } else if (move == "B'") {
            RotateSide(cs.back, -90);
        } else if (move == "B2") {
            RotateSide(cs.back, -180);
        } else if (move == "L") {
            RotateSide(cs.left, 90);
        } else if (move == "L'") {
            RotateSide(cs.left, -90);
        } else if (move == "L2") {
            RotateSide(cs.left, -180);
        } else if (move == "R") {
            RotateSide(cs.right, 90);
        } else if (move == "R'") {
            RotateSide(cs.right, -90);
        } else if (move == "R2") {
            RotateSide(cs.right, -180);
        } else if (move == "F") {
            RotateSide(cs.front, 90);
        } else if (move == "F'") {
            RotateSide(cs.front, -90);
        } else if (move == "F2") {
            RotateSide(cs.front, -180);
        } else if (move == "D") {
            RotateSide(cs.bot, 90);
        } else if (move == "D'") {
            RotateSide(cs.bot, -90);
        } else if (move == "D2") {
            RotateSide(cs.bot, -180);
        }
    }

    void RotateSide(List<GameObject> side, float angle) {
        pivotRotation pr = side[4].transform.parent.GetComponent<pivotRotation>();
        pr.StartAutoRotate(side, angle);
    }
}
