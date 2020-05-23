using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public GameObject manager;
    public GameObject ImagenAudio;
    private AudioSource bgAudio;
    bool audioState=true;

    // Start is called before the first frame update
    void Start()
    {
       bgAudio=  manager.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ImagenAudio.GetComponent<Animator>().SetBool("Music",audioState);
    }


    public void audioCambiar(){
        audioState = !audioState;
        
        if(audioState){
            bgAudio.volume = 1;
        }else{
            bgAudio.volume = 0;
        }

    }

    public void play(){
        SceneManager.LoadScene("un");
    }

    public void howTo(){
        SceneManager.LoadScene("how");
    }
    public void back(){
        SceneManager.LoadScene("Menu");
    }
}
