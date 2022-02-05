using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pivotRotation : MonoBehaviour
{
    private List<GameObject> activeSide;
    private Vector3 localForward;
    public GvrReticlePointer reticle;
    Vector3 reticleRef;
    public bool dragging = false;
    private leerCubo readCube;
    private estadoCubo cubeState;
    private bool autoRotating = false;
    private float sensitivity = 40.0f;
    private float rotationspeed = 300.0f; 
    private Vector3 rotation;

    private Quaternion targetQuaternion;

    // Start is called before the first frame update
    void Start()
    {
        readCube = FindObjectOfType<leerCubo>();
        cubeState = FindObjectOfType<estadoCubo>();
        controllercommand.stopDragging += stopDragging;
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging) {
            SpinSide(activeSide);
        }
        if (autoRotating) {
            autoRotate();
        }
    }

    public void StartAutoRotate(List<GameObject> side, float angle) {
        cubeState.PickUp(side);
        Vector3 localForward = Vector3.zero - side[4].transform.parent.transform.localPosition;
        targetQuaternion = Quaternion.AngleAxis(angle, localForward) * transform.localRotation;
        activeSide = side;
        autoRotating = true;
    }

    private void SpinSide(List<GameObject> side) {
        rotation = Vector3.zero;

        Vector3 reticleOffset = (reticle.coordenateReticle - reticleRef);
        Debug.Log(reticle.coordenateReticle + " " + reticleRef);
        if(side == cubeState.front) {
            rotation.z = (reticleOffset.x + reticleOffset.y) * sensitivity * -1;
        }
        if(side == cubeState.top) {
            rotation.y = (reticleOffset.x + reticleOffset.y) * sensitivity * -1;
        }
        if(side == cubeState.bot) {
            rotation.y = (reticleOffset.x + reticleOffset.y) * sensitivity * -1;
        }
        if(side == cubeState.left) {
            rotation.x = (reticleOffset.x + reticleOffset.y) * sensitivity * 1;
        }
        if(side == cubeState.right) {
            rotation.x = (reticleOffset.x + reticleOffset.y) * sensitivity * -1;
        }
        if(side == cubeState.back) {
            rotation.z = (reticleOffset.x + reticleOffset.y) * sensitivity * -1;
        }

        transform.Rotate(rotation, Space.Self);

        reticleRef = reticle.coordenateReticle;
    }

    public void Rotate(List<GameObject> side) {
        activeSide = side;
        reticleRef = reticle.coordenateReticle;
        dragging = true;

        localForward = Vector3.zero - side[4].transform.parent.transform.localPosition;

    }

    public void stopDragging() {
        if (dragging) {
            RotateToRightAngle();
        }
    }

    public void RotateToRightAngle() {
        Vector3 vec = transform.localEulerAngles;

        vec.x = Mathf.Round(vec.x / 90) * 90;
        vec.y = Mathf.Round(vec.y / 90) * 90;
        vec.z = Mathf.Round(vec.z / 90) * 90;

        targetQuaternion.eulerAngles = vec;
        autoRotating = true;
    }

    private void autoRotate() {
        var step = rotationspeed * Time.deltaTime;
        dragging = false;
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetQuaternion, step);

        if (Quaternion.Angle(transform.localRotation, targetQuaternion) <= 1) {
            transform.localRotation = targetQuaternion;

            autoRotating = false;

            cubeState.PutDown(activeSide, transform.parent); // cuando ya hemos movido rehacemos la jerarquia     
            
            readCube.LeerEstado( );
            estadoCubo.autoRotating = false;
        }
    }

}
