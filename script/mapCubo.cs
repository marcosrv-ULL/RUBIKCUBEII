using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapCubo : MonoBehaviour
{
    estadoCubo estadocubo;

    public Transform top;
    public Transform bot;
    public Transform left;
    public Transform right;
    public Transform front;
    public Transform back;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set() {
        estadocubo = FindObjectOfType<estadoCubo>();
        UpdateMap(estadocubo.front, front);
        UpdateMap(estadocubo.back, back);
        UpdateMap(estadocubo.left, left);
        UpdateMap(estadocubo.right, right);
        UpdateMap(estadocubo.top, top);
        UpdateMap(estadocubo.bot, bot);
    }

    void UpdateMap(List<GameObject> face, Transform side) {
        int i = 0;
        
        foreach (Transform map in side) {
            if (face[i].name[0] == 'f') {
                map.GetComponent<Image>().color =  Color.red;
            }
            if (face[i].name == "back") {
                map.GetComponent<Image>().color = new Color(1, 0.5f, 0, 1);
            }
            if (face[i].name[0] == 'l') {
                map.GetComponent<Image>().color =  Color.yellow;
            }
            if (face[i].name[0] == 'r') {
                map.GetComponent<Image>().color = new  Color(0.5f, 0, 0.5f);
            }
            if (face[i].name[0] == 't') {
                map.GetComponent<Image>().color = Color.blue;
            }
            if (face[i].name == "bottom") {
                map.GetComponent<Image>().color =  Color.green;
            }
            i++;
        }
    }
}
