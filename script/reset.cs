using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class reset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        
    }
    
    public void resettimer() {
        controllercommand1.ResetTimer();
    }
}

public static class controllercommand1 {
    public static Action ResetTimer;
}
