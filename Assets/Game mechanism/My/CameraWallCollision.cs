using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion;
public class CameraWallCollision : MonoBehaviour {
    public CameraController cameraController;
    public GameObject cameraHelper;
    public LayerMask layerMask;
    public GameObject collObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        RaycastHit Hit;
        if (Physics.Raycast(cameraHelper.transform.position, cameraHelper.transform.forward, out Hit, cameraController.distance, layerMask))
        {
            cameraController.cameraCollision = true;
            collObject = Hit.collider.gameObject;
            cameraController.addDistance = Hit.distance;
        }
        else
        {
            cameraController.cameraCollision = false;
            collObject = null;
        }
        cameraHelper.transform.LookAt(cameraController.secondCameraHelper.transform.position);
    }
}
