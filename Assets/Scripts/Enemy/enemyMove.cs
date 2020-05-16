using UnityEngine;

public class enemyMove : MonoBehaviour {
    public float enemySpeed;

    private void Start() {
        enemySpeed = 7f;
    }

    private void Update() {
       transform.position = transform.position + new Vector3(-enemySpeed*Time.deltaTime,0,0);
    }
}