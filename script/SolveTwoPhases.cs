using System.Collections;
using System.Collections.Generic;
using Kociemba;
using UnityEngine;

public class SolveTwoPhases : MonoBehaviour
{
    public leerCubo rc;
    public estadoCubo cs;
    // Start is called before the first frame update
    void Start()
    {
        rc = FindObjectOfType<leerCubo>();
        cs = FindObjectOfType<estadoCubo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Solver() {
        rc.LeerEstado();
        string movimientoscadena = cs.GetStateString();
        print(movimientoscadena);

        string info = "";
        string solution = SearchRunTime.solution(movimientoscadena, out info, buildTables: true);
        List<string> solutionList = StringToList(solution);
        Debug.Log(solutionList);
        automate.listaMovimientos = solutionList;
        print(info);
    }


    List<string> StringToList(string solution) {
        List<string> solutionList = new List<string>(solution.Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries));
        return solutionList;
    }
}

