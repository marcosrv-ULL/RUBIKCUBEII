using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotarPuzzle : MonoBehaviour
{
    Vector2 rotacionActual;
    public GameObject cube;
    public float speed = 1.0f;
    bool left = false;
    bool top = false;
    bool bot = false;
    bool right = false;
    float accRotl = 0;
    float accRotr = 0;
    float accRotb = 0;
    float accRott = 0;

    void Update() {
        if(left) {
            cube.transform.Rotate(0,90.0f * Time.deltaTime * speed, 0, Space.World);
            accRotl += 90.0f * Time.deltaTime * speed;
            if (accRotl >= 90.0f) {
                left = false;
                accRotl = 0;
            } 
        } else if (top) {
            cube.transform.Rotate(0,0,-90.0f  * Time.deltaTime * speed, Space.World);
            accRott += -90.0f * Time.deltaTime * speed;
            if (accRott <= -90.0f) {
                top = false;
                accRott = 0;
            } 
        } else if (bot) {
            cube.transform.Rotate(0,0,90.0f  * Time.deltaTime * speed, Space.World);
            accRotb += 90.0f * Time.deltaTime * speed;
            if (accRotb >= 90.0f) {
                bot = false;
                accRotb = 0;
            } 
        } else if (right) {
            cube.transform.Rotate(0,-90.0f  * Time.deltaTime * speed,0 , Space.World);
            accRotr += -90.0f * Time.deltaTime * speed;
            if (accRotr <= -90.0f) {
                right = false;
                accRotr = 0;
            }
        }
    }

    public void leftRotar() {
        left = !left;
    }

    public void rightRotar() {
       right = !right;
    }

    public void topRotar() {
       top = !top; 
    }

    public void botRotar() {
       bot = !bot; 
    }

    public void resetRotation() {
        cube.transform.rotation = Quaternion.Euler(0,0,0);
    }
}
