using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour
{
    float vida;
    Animator EnemyAnim;
    Rigidbody2D Enemy_rb;
    Collider2D EnemyCol;

    [SerializeField]
    GameObject HP;

    [SerializeField]
    GameObject EP;
    
    
    private GameObject Ply;

  
    PlayerController control;

    GameObject manager;
    contador conta;
    // Start is called before the first frame update
    void Start()
    {
        Ply = GameObject.FindGameObjectWithTag("Player");
        manager = GameObject.FindGameObjectWithTag("Manager");
        vida = 100f;
        EnemyAnim = GetComponent<Animator>();
        Enemy_rb = GetComponent<Rigidbody2D>();
        EnemyCol = GetComponent<Collider2D>();
        control = Ply.GetComponent<PlayerController>();
        conta = manager.GetComponent<contador>();
    }

    private void OnTriggerExit2D(Collider2D other) {
        float damageSword;
        if(other.gameObject.tag == "Sword"){
            damageSword = control.Damage;
            
            if(vida<= damageSword){
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
               
                conta.sumar();

    }
}
