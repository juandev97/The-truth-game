using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public float speed;
    Animator anim;
    public bool grounded;
    
    public Image barraX;

    public bool attackReady = false;
 
    public int hash ;

    //jump 
    public float jumpForece;
    public bool jump;

    // ataques 
    [SerializeField]
    GameObject SwordHitbox;

    private PlayerMana manaSystem;
    [SerializeField]
    private float damageVal;
    public bool atack;
    [SerializeField]
    float waitAttack;

    public ParticleSystem particulas;
    Rigidbody2D rb;
    Collider2D playerCol;



    // Start is called before the first frame update
    void Start()
    {
        manaSystem = GetComponent<PlayerMana>();
        playerCol = GetComponent<Collider2D>();
        waitAttack = .86f;
        rb = GetComponent<Rigidbody2D>();
        jumpForece = 15f;
        jump = false;
        anim = GetComponent<Animator>();
        SwordHitbox.SetActive(false);
        damageVal = 50f;
        anim.SetInteger("Xattack",0);
        barraX.enabled = false;
        particulas.Stop();
        
    }

    // Update is called once per frame
    void Update()
    {
        playerCol.enabled = !atack;
        anim.SetBool("IsJump",!grounded);
//'Saltar'
     if(Input.GetKeyDown(KeyCode.S) && grounded)
        {
            jump = true;
        }

// atacar
    
    if(Input.GetKeyDown(KeyCode.A))
    {
        if(!atack){
        atack = true;  
        Damage = 50f;
        anim.SetTrigger("IsAttacking");
        StartCoroutine(DoAtacar(waitAttack));
        }
    }

// ataque especial 

CargarAttack();

//'Mover derecha'
     if(Input.GetKey(KeyCode.RightArrow) && !atack)
     {
         correr(speed);
         transform.localScale = new Vector3(.1f,.1f,1);
       
    }
     
//'mover izquierda'
     if(Input.GetKey(KeyCode.LeftArrow) && !atack)
     {
        correr(-speed);
        transform.localScale = new Vector3(-.1f,.1f,1);
        
     }

//'quedarse quieto'
     if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow)  && !atack)
     {
        anim.SetBool("IsRunning",false);
     }
    }



// correr
void correr(float vel){

        anim.SetBool("IsRunning",true);
        transform.Translate(vel * Time.deltaTime, 0,0);   
     }

// saltar

    void FixedUpdate() 
{
    if(jump)
    {
       rb.AddForce(new Vector3(0,jumpForece,0),ForceMode2D.Impulse);  
       jump = false;  
    }
        
}
// atacar



IEnumerator DoAtacar(float t){
    SwordHitbox.SetActive(true);
    yield return new WaitForSeconds(t);
    SwordHitbox.SetActive(false);
    atack = false;
}


IEnumerator XAnimation(){
      anim.SetInteger("Xattack",2);
      yield return new WaitForSeconds(.65f);
      anim.SetInteger("Xattack",0);
  }

// varibales de tiempo boton presionado 
    float downTime, upTime, pressTime = 0f;




void CargarAttack(){
      if(Input.GetKeyDown(KeyCode.D) && !attackReady)
    {
        if(!atack){
            atack = true;
            downTime = Time.time;
            anim.SetInteger("Xattack",1);
            attackReady = true;
            particulas.Play();
            
        }
    }
// descargar


    if(Input.GetKeyUp(KeyCode.D))
    {
        pressTime = Time.time - downTime;
        float holdTimeNomalized = Mathf.Clamp01(pressTime/ 2f);
        attackReady = false;
        barraX.enabled = false;
//comprobamos el mana
        if(manaSystem.GastarMana(holdTimeNomalized*10)){
           
            
            StartCoroutine(XAnimation());
            StartCoroutine(DoAtacar(waitAttack));        
            Damage = CalculateHoldDown(pressTime);
            
            particulas.Stop();
            if(holdTimeNomalized == 1)
                EnergyWaveInvocate();
        }else{
            particulas.Stop();
            anim.SetInteger("Xattack",0);           
            
        }
      
        }
    
    if(Input.GetKey(KeyCode.D)){
        barraX.enabled = true;
        pressTime = Time.time - downTime;
        barraX.fillAmount = pressTime/2f;
        var emision = particulas.emission;
        emision.rateOverTime =  20f* Mathf.Clamp01(pressTime/2f); 
    }
    }

public float Damage{
    get{return damageVal;}
    set{damageVal = value;}
}

private float CalculateHoldDown(float holdTime){
    float maxForceHoldDownTime = 3f;
    float holdTimeNomalized = Mathf.Clamp01(holdTime/ maxForceHoldDownTime);
    damageVal= 50f;
    damageVal = (1+holdTimeNomalized) * damageVal;
    return damageVal;
    }


public Transform Fuente;
public GameObject Bullet;


void EnergyWaveInvocate(){
    GameObject wave = (GameObject)Instantiate(Bullet, Fuente.position  , transform.rotation);
    Destroy(wave,10f);
}
}