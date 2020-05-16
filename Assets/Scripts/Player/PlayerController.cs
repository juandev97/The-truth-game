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
 
    

    //jump 
    public float jumpForece;
    public bool jump;

    // ataques 
    [SerializeField]
    GameObject SwordHitbox;
    [SerializeField]
    private float damageVal;
    public bool atack;
    [SerializeField]
    float waitAttack;

    Rigidbody2D rb;
    Collider2D playerCol;



    // Start is called before the first frame update
    void Start()
    {
        playerCol = GetComponent<Collider2D>();
        waitAttack = .86f;
        rb = GetComponent<Rigidbody2D>();
        jumpForece = 15f;
        jump = false;
        anim = GetComponent<Animator>();
        SwordHitbox.SetActive(false);
        damageVal = 10f;
        anim.SetInteger("Xattack",0);
        barraX.enabled = false;
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
    damageVal = 50f;
    if(Input.GetKeyDown(KeyCode.A))
    {
        if(!atack){
        atack = true;  
        damageVal = 50f;
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
          if (GetComponent<SpriteRenderer>().flipX){
             GetComponent<SpriteRenderer>().flipX = false;
         }
     }
//'mover izquierda'
     if(Input.GetKey(KeyCode.LeftArrow) && !atack)
     {
        correr(-speed);
        if (!GetComponent<SpriteRenderer>().flipX){
             GetComponent<SpriteRenderer>().flipX = true;
         }
        
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

public float getDamage(){
    return damageVal;
}

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
            
        }
    }
// descargar

    if(Input.GetKeyUp(KeyCode.D))
    {
        attackReady = false;
        pressTime = Time.time - downTime;
        StartCoroutine(XAnimation());
        StartCoroutine(DoAtacar(waitAttack));
        damageVal = CalculateHoldDown(pressTime);
        barraX.enabled = false;
        }
    
    if(Input.GetKey(KeyCode.D)){
        barraX.enabled = true;
        pressTime = Time.time - downTime;
        barraX.fillAmount = pressTime/2f;
    }
    }

private float CalculateHoldDown(float holdTime){
    float maxForceHoldDownTime = 2f;
    float holdTimeNomalized = Mathf.Clamp01(holdTime/ maxForceHoldDownTime);
    damageVal = (1+holdTimeNomalized) * damageVal;
    return damageVal;
    }
}