using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour
{
    public Text latitud;
    public Text longitud;
    public Text altitud;
    public Text status;

    // Start is called before the first frame update
    IEnumerator Start()
    {   
        latitud = GameObject.Find("latitud").GetComponent<Text>();       
        longitud = GameObject.Find("longitud").GetComponent<Text>();   
        status = GameObject.Find("status").GetComponent<Text>();  
        status.text = "off";
        
        yield return new WaitForSeconds(3);
        // Check if the user has location service enabled.
        if (!Input.location.isEnabledByUser)
        {   
            status.text = "location NOT enabled";
            yield break;
        }

        // Starts the location service.
        Input.location.Start(); 

        // Waits until the location service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // If the service didn't initialize in 20 seconds this cancels location service use.
        if (maxWait < 1)
        {
            status.text = "Timed out";
            yield break;
        }

        // If the connection failed this cancels location service use.
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            status.text = "Unable to determine device location";
            yield break;
        }
        else
        {
            status.text = "Running";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.location.status == LocationServiceStatus.Running) 
        {   
           
            latitud.text = "Latitud: " + Input.location.lastData.latitude.ToString();
            longitud.text = "Longitud: " + Input.location.lastData.longitude.ToString();
            altitud.text = "Altitud: " + Input.location.lastData.altitude.ToString();
        }
        
    }
}