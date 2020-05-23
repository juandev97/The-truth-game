using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ira_FocusOnPlayer : MonoBehaviour {
    public Transform objetivo;
    float posicion;

    Vector2 direccion;
   
    private void Start() {
 
        
    }

    private void Update() {
        posicion = objetivo.position.x - transform.position.x;

        direccion = objetivo.position - transform.position;

        if(posicion <= 0){
            transform.localScale = new Vector3 (0.15f,transform.localScale.y,transform.localScale.z);
        }else if(posicion > 0){
            transform.localScale = new Vector3 (-0.15f,transform.localScale.y,transform.localScale.z);
        }
    }

    
public bool correr = false;


    private void FixedUpdate() {
        direccion.Normalize();
        Vector2 mov = direccion;
        if(correr){
            auxiliarCorrer(mov);
        }
    }
public void auxiliarCorrer(Vector2 direccion){
    
    transform.position =  new Vector2 (transform.position.x + (direccion.x * 5f * Time.deltaTime), transform.position.y);
    StartCoroutine(waitAndStop());
}
IEnumerator waitAndStop(){
    yield return new WaitForSeconds(3f);
    transform.position = transform.position ;
    correr = false;
}


}