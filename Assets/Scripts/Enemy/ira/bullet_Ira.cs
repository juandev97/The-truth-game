using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_Ira : MonoBehaviour
{
    public float speed;
    private GameObject ira;
    int valor;
    // Start is called before the first frame update
    void Start()
    {
     ira = GameObject.FindGameObjectWithTag("Ira");  

     valor = (int) Mathf.Round(ira.transform.localScale.x*10f) ; 
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.localScale = new Vector3 (valor * 1.5f ,1.5f,1);
        transform.Translate(transform.right *valor* speed * Time.deltaTime);

        StartCoroutine(destruir());
    }

    IEnumerator destruir(){
        yield return new WaitForSeconds(3.5f);
        Destroy(this.gameObject);
    }
}
