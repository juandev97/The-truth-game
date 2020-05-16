using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrounds : MonoBehaviour
{
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "ground")
        {
          player.grounded = true;  
        }           
    }

    private void OnCollisionStay(Collision other) {
        if(other.gameObject.tag == "ground")
        {
          player.grounded = true;  
        }      
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "ground")
        {
          player.grounded = false;  
        }      
    }

}
