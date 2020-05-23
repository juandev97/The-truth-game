using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class contador : MonoBehaviour
{

    private int cuenta;
    public Text txt;
    public int contado{
    get{return cuenta;}
    set{cuenta = value;}
    }
    // Start is called before the first frame update

    private void Update() {
        if(contado < 10){
            txt.text = "X0"+contado;
        }else{
        txt.text = "X"+contado;
        }

        if(contado >= 15){
            SceneManager.LoadScene("dos");
        }
    }
    public void sumar(){
         contado+=1;
    }
}
