using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour
{
    float vida;
    Animator EnemyAnim;
    Rigidbody2D Enemy_rb;
    Collider2D EnemyCol;
    int contador = 0;
    [SerializeField]
    GameObject HP;

    [SerializeField]
    GameObject EP;
    
    
    public GameObject Ply;

  
    PlayerController control;

    // Start is called before the first frame update
    void Start()
    {
        vida = 100f;
        EnemyAnim = GetComponent<Animator>();
        Enemy_rb = GetComponent<Rigidbody2D>();
        EnemyCol = GetComponent<Collider2D>();
        control = Ply.GetComponent<PlayerController>();
    }

    private void OnTriggerExit2D(Collider2D other) {
        float damageSword;
        if(other.gameObject.tag == "Sword"){
            damageSword = 50f + control.getDamage();
            if(vida< damageSword){
                    morir();
            }else
            {
                vida = vida - damageSword;
                Enemy_rb.AddForce(new Vector3(250,0,0));
                EnemyAnim.SetTrigger("Enemy_hurt");
            }

        }
        
    }

    void morir(){

                EnemyCol.enabled = false;
                EnemyAnim.SetTrigger("Enemy_die");
                Destroy(this.gameObject,1.6f);
                int ProbDeDrop = Random.Range(1,9);

                if(ProbDeDrop <= 3){
                    Instantiate(HP,transform.position,Quaternion.identity);
                }else if(ProbDeDrop > 6){
                    Instantiate(EP,transform.position,Quaternion.identity);
                }
               
                contador+=1;

    }
}
