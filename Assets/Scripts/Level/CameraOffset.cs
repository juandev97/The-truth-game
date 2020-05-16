using UnityEngine;

public class CameraOffset : MonoBehaviour {
    
private Transform cameraTransform;
private Vector3 lastCameraPosition;


[SerializeField]
Vector2 paralaxEfectMultiplier;



private void Start() {
    cameraTransform = Camera.main.transform;
    lastCameraPosition = cameraTransform.position;
    
}

private void LateUpdate() {
    Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
    transform.position += new Vector3 (deltaMovement.x* paralaxEfectMultiplier.x, deltaMovement.y* paralaxEfectMultiplier.y,deltaMovement.z);
    lastCameraPosition = cameraTransform.position;
}

}