using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyWaveMove : MonoBehaviour
{
    public float speed;
    private GameObject ply;
    int valor;
    // Start is called before the first frame update
    void Start()
    {
     ply = GameObject.FindGameObjectWithTag("Player");  

     valor = (int) Mathf.Round(ply.transform.localScale.x*10f) ; 
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.localScale = new Vector3 (valor * 4.5f ,4.5f,1);
        transform.Translate(transform.right *valor* speed * Time.deltaTime);
    }
}
