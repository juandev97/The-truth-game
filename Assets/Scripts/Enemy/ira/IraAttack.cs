 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IraAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] points;
    public GameObject bullet;
    private Animator anim;

    public float timeBtwAtack;
    void Start()
    {
        
        anim = GetComponent<Animator>();
        InvokeRepeating("atacar",timeBtwAtack,3.5f);
           
    }

    // Update is called once per frame
    void Update()
    {
     
    }


    void atacar(){
        for(int i=0;i<points.Length;i++){
            Instantiate(bullet,points[i].position,points[i].rotation);
        }
    }
}
