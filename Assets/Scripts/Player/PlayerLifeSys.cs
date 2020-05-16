using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerLifeSys : MonoBehaviour {
    
    public int damage;
   
    private Rigidbody2D playerRb;
    private Animator playerAnim;
    public Image healthBar;

    private float vidaInicial;
    private float vidaActual;
 
    private void Start() {
        damage = 5;
        vidaInicial = 100f;
        vidaActual = 0;
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        healthBar.fillAmount = vidaActual/vidaInicial;
              
    }

 private void OnTriggerExit2D(Collider2D other) {
          if(other.gameObject.tag == "Enemy" && !(this.gameObject.tag == "Sword")){
            playerAnim.SetTrigger("IsHurt");
            playerRb.AddForce(new Vector3(80,100,0));
            vidaActual = vidaActual + damage;
            healthBar.fillAmount = vidaActual/vidaInicial;
            
            if(vidaActual >= vidaInicial){
                murio();
            }
          }

          if(other.gameObject.tag == "potion"){
              curar(20f);
              Destroy(other.gameObject,.2f);
          }
        
           
    }

    void murio(){
    playerAnim.SetTrigger("Die");
    SceneManager.LoadScene("GameOver");
    }

void curar(float cura){
    vidaActual = vidaActual - cura;
    if(vidaActual < 0){
        vidaActual = 0;
    } 
    healthBar.fillAmount = vidaActual/vidaInicial;
}
}

