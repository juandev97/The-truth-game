using UnityEngine;

public class Paralax : MonoBehaviour {
    
private Transform cameraTransform;
private Vector3 lastCameraPosition;
float textureUnitSizeX;

[SerializeField]
Vector2 paralaxEfectMultiplier;



private void Start() {
    cameraTransform = Camera.main.transform;
    lastCameraPosition = cameraTransform.position;
    Sprite sprite = GetComponent<SpriteRenderer>().sprite;
    Texture2D texture = sprite.texture;
    textureUnitSizeX = texture.width / sprite.pixelsPerUnit;

}

private void LateUpdate() {
    Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
    transform.position += new Vector3 (deltaMovement.x* paralaxEfectMultiplier.x, deltaMovement.y* paralaxEfectMultiplier.y,deltaMovement.z);
    lastCameraPosition = cameraTransform.position;

    if(Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX){
        float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
        transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
    }
}

}