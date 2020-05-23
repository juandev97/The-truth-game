using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerLifeSys : MonoBehaviour {
    
    public int damage;
   
    private Rigidbody2D playerRb;
    private Animator playerAnim;
    public Image healthBar;

    [SerializeField]
    private float vidaInicial;
    [SerializeField]
    private float vidaActual;
 
    AudioSource dieSound;

    private void Start() {
        damage = 5;
        vidaInicial = 150f;
        vidaActual = 0;
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        healthBar.fillAmount = vidaActual/vidaInicial;
        dieSound = GetComponent<AudioSource>();
              
    }

 private void OnTriggerEnter2D(Collider2D other) {
          if((other.gameObject.tag == "Ira" || other.gameObject.tag == "Enemy") && !(this.gameObject.tag == "Sword")){
            
            if(vidaActual >= vidaInicial){
                murio();
            }else{
            playerAnim.SetTrigger("IsHurt");
            playerRb.AddForce(new Vector3(80,100,0));
            vidaActual = vidaActual + damage;
            healthBar.fillAmount = vidaActual/vidaInicial;
            }     
          }

          if(other.gameObject.name == "Health Potion(Clone)"){
              
              curar(15f);
              Destroy(other.gameObject,.1f);
          }
        
           
    }

    void murio(){

    dieSound.Play();
    playerAnim.SetTrigger("Die");
    StartCoroutine(gameover());
    }


void curar(float cura){
    
    vidaActual = vidaActual - cura;
    if(vidaActual < 0){
        vidaActual = 0;
    } 
    healthBar.fillAmount = vidaActual/vidaInicial;
 }

 IEnumerator gameover(){
     yield return new WaitForSeconds(.8f);
     SceneManager.LoadScene("GameOver");
 }
}

