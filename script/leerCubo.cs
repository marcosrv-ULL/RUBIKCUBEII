using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class leerCubo : MonoBehaviour
{
    public Transform tTop;
    public Transform tBot;
    public Transform tLeft;
    public Transform tRight;
    public Transform tFront;
    public Transform tBack;

    // Añadimos mascara de caras
    private int mascaraCapa = 1 << 8; // Capa para las caras
    estadoCubo estadocubo;
    mapCubo mapaCubo;
    public GameObject emptyGO;

    private List<GameObject> frontRays = new List<GameObject>();
    private List<GameObject> backRays = new List<GameObject>();
    private List<GameObject> topRays = new List<GameObject>();
    private List<GameObject> botRays = new List<GameObject>();
    private List<GameObject> rightRays = new List<GameObject>();
    private List<GameObject> leftRays = new List<GameObject>();


    void Start()
    {
        SetRayTransforms();
        estadocubo = FindObjectOfType<estadoCubo>();
        mapaCubo = FindObjectOfType<mapCubo>();
        LeerEstado ();
        estadoCubo.started = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeerEstado () {
        estadocubo = FindObjectOfType<estadoCubo>();
        mapaCubo = FindObjectOfType<mapCubo>();


        
        estadocubo.top = ReadFace(topRays, tTop);
        estadocubo.bot = ReadFace(botRays, tBot);
        estadocubo.left = ReadFace(leftRays, tLeft);
        estadocubo.right = ReadFace(rightRays, tRight);
        estadocubo.back = ReadFace(backRays, tBack);
        estadocubo.front = ReadFace(frontRays, tFront);
        mapaCubo.Set();
        
    }

    void SetRayTransforms() {
        frontRays = BuildRays(tFront, new Vector3(180,180,0));
        backRays = BuildRays(tBack, new Vector3(180,0,0));
        topRays = BuildRays(tTop, new Vector3(90,90,0));
        botRays = BuildRays(tBot, new Vector3(270,90,0));
        rightRays = BuildRays(tRight, new Vector3(0,-90,0));
        leftRays = BuildRays(tLeft, new Vector3(0,90,0));
    }

    List<GameObject> BuildRays(Transform rayTransform, Vector3 direction) {
        // The ray count is used to name the rays so we can be sure they are in the right order.
        int rayCount = 0;
        List<GameObject> rays = new List<GameObject>();
        // This creates 9 rays in the shape of the side of the cube with
        // Ray 0 at the top left and Ray 8 at the bottom right:
        //  |0|1|2|
        //  |3|4|5|
        //  |6|7|8|

        for (int y = 1; y > -2; y--)
        {
            for (int x = -1; x < 2; x++)
            {
                Vector3 startPos = new Vector3( rayTransform.localPosition.x + x,
                                                rayTransform.localPosition.y + y,
                                                rayTransform.localPosition.z);
                GameObject rayStart = Instantiate(emptyGO, startPos, Quaternion.identity, rayTransform);
                rayStart.name = rayCount.ToString();
                rays.Add(rayStart);
                rayCount++;
            }
        }
        rayTransform.localRotation = Quaternion.Euler(direction);
        return rays;
    }

    public List<GameObject> ReadFace(List<GameObject> rayStarts, Transform rayTransform) {
        List<GameObject> facesHit = new List<GameObject>();

        foreach (GameObject rayStart in rayStarts)
        {
            Vector3 ray = rayStart.transform.position;
            RaycastHit hit;

            // Does the ray intersect any objects in the layerMask?
            if (Physics.Raycast(ray, rayTransform.forward, out hit, 400.0f, mascaraCapa))
            {
                facesHit.Add(hit.collider.gameObject);
                //print(hit.collider.gameObject.name);
                Debug.DrawRay(ray, rayTransform.forward * 1000, Color.green);
            }
            else
            {
                Debug.DrawRay(ray, rayTransform.forward * 1000, Color.green);
            }
        }
        return facesHit;
    }
}
