using UnityEngine;
//using UnityEngine.UI;

public class tutorialManage : MonoBehaviour {
    
    public GameObject pn;
    Collider2D col;
private void Start() {
    pn.SetActive(false);
    col = GetComponent<Collider2D>();
}
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "feets"){
            pn.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name =="feets"){
            pn.SetActive(false);
            col.isTrigger = false;
        }
    }
}