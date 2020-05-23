using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class Ira_life : MonoBehaviour {
    float vidaMaxima;

    [SerializeField]
    float vidaActual;

    Animator Ira_anim;
    public Image Ira_lifebar;
    PlayerController control;    
    public GameObject Ply;
    private void Start() {
        vidaMaxima = 1200;
        vidaActual = 0;
        Ira_anim = GetComponent<Animator>();
        control = Ply.GetComponent<PlayerController>();

    }

    private void Update() {
        Ira_lifebar.fillAmount = vidaActual/vidaMaxima;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Sword"){
            if(vidaActual >= vidaMaxima){
                muerto();
            }else{
            Ira_anim.SetTrigger("Damaged");
            vidaActual+= control.Damage;
            }
        }
    }

 
    void muerto(){
        Ira_anim.SetTrigger("Die");
        StartCoroutine(Fin());
    }

       IEnumerator Fin(){
        yield return new WaitForSeconds(.75f);
        SceneManager.LoadScene("End");
    }
}