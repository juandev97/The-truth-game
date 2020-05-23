using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{
    float manaActual;
    float manaInicial;
    public Image manaBar;

    // Start is called before the first frame update
    void Start()
    {
        manaInicial = 100f;
        manaActual= 0f;
        manaBar.fillAmount = manaActual/manaInicial;       
               
        
    }

private void OnTriggerExit2D(Collider2D other) {
     if(other.gameObject.name == "Energy potion(Clone)"){
              manaActual = manaActual - 15f;
              manaBar.fillAmount = manaActual/manaInicial;
              Destroy(other.gameObject,.1f);
          }
}

    public bool GastarMana(float cantidad){
        if(manaActual+ cantidad <= manaInicial){
            manaActual = manaActual + cantidad;
            manaBar.fillAmount = manaActual/manaInicial;
            return true;
        }else
        {
            return false;
        }
         
             
    }
}
