using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    public GameObject finalPaint;
    public GameObject finalPaintGood;
    public GameObject finalPaintBad;
    private Renderer renderer;
    private Color baseColor;
    public GameObject selObj;
    private GameObject player;
    private GameObject camera;
    private bool objSelected;
    private Vector3 basePos;
    private Vector3 baseRot;
    private Vector3 holdingPos;
    private Vector3 holdingRot;
    private Vector3 camRot;
    private Vector3 camHoldingRot;
    private bool looking;
    private bool lightOn;
    private bool radioOn;
    public AudioSource lamp;
    public AudioSource radio1;
    public AudioSource radio2;
    public AudioSource radio3;
    public AudioSource radio4;
    public AudioSource radio5;
    public AudioSource radio6;
    public AudioSource radio7;
    public AudioSource radio8;
    private AudioSource currRadio;
    public AudioSource radioSound;
    public AudioSource putItem;
    public GameObject reticle;
    Light light;
    private CollectibleManager reference;
    List<int> collectedCollectibles;
    
    // Start is called before the first frame update
    void Start()
    {
        reference = FindObjectOfType<CollectibleManager>();
        collectedCollectibles = reference.collectedCollectibles;
        light = GameObject.FindWithTag("light").GetComponent<Light>();
        renderer = GetComponent<Renderer>();
        baseColor = renderer.material.color;
        player = GameObject.FindWithTag("Player");
        objSelected = false;
        basePos = selObj.transform.position;
        baseRot = selObj.transform.eulerAngles;
        camera = GameObject.FindWithTag("MainCamera");
        looking = false;
        if(light.enabled){
            lightOn = true;
        }else{
            lightOn = false;
        }
        lamp = camera.transform.Find("lamp").GetComponent<AudioSource>();
        radio1 = camera.transform.Find("radio1").GetComponent<AudioSource>();
        radio2 = camera.transform.Find("radio2").GetComponent<AudioSource>();
        radio3 = camera.transform.Find("radio3").GetComponent<AudioSource>();
        radio4 = camera.transform.Find("radio4").GetComponent<AudioSource>();
        radio5 = camera.transform.Find("radio5").GetComponent<AudioSource>();
        radio6 = camera.transform.Find("radio6").GetComponent<AudioSource>();
        radio7 = camera.transform.Find("radio7").GetComponent<AudioSource>();
        radio8 = camera.transform.Find("radio8").GetComponent<AudioSource>();
        radioSound = camera.transform.Find("radioSound").GetComponent<AudioSource>();
        putItem = camera.transform.Find("putItem").GetComponent<AudioSource>();
        reticle = GameObject.FindWithTag("reticle");
        switch(collectedCollectibles.Count){
            case 0:
                currRadio = radio1;
                break;
            case 1:
                currRadio = radio2;
                break;
            case 2:
                currRadio = radio3;
                break;
            case 3:
                currRadio = radio4;
                break;
            case 4:
                currRadio = radio5;
                break;
            case 5:
                currRadio = radio6;
                break;
            case 6:
                currRadio = radio7;
                break;
        }
        currRadio.Play();
        radioOn = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseEnter(){
        if(!looking){
            renderer.material.color = new Color(0.2f,1f,0.2f,0.3f);
        }
        objSelected = true;
    }
    
    private void OnMouseDown(){
        if(objSelected && selObj.CompareTag("badInspo") && collectedCollectibles.Count == 6){
            putItem.Play();
            currRadio.Stop();
            currRadio = radio8;
            currRadio.Play();
            radioOn = true;
        } else if(objSelected && selObj.CompareTag("goodInspo") && collectedCollectibles.Count == 6){
            putItem.Play();
            currRadio.Stop();
            currRadio = radio1;
            currRadio.Play();
            radioOn = true;
        }else if(objSelected && selObj.CompareTag("lamp")){
            lamp.Play();
            if(lightOn){
                light.enabled = false;
                lightOn = false;
            } else {
                light.enabled = true;
                lightOn = true;
            }
        } else if(objSelected && selObj.CompareTag("Radio")){
            if(radioOn){
                //set radio volume to 0
                radioSound.Play();
                currRadio.Stop();
                radioOn = false;
                //play radio off sound
            } else {
                //set radio volume to 100 or base volume
                radioSound.Play();
                currRadio.Play();
                radioOn = true;
                //play radio on sound
            }
        }else if(objSelected && selObj.CompareTag("awakeChair")){
            objSelected = false;
            SceneManager.LoadScene("Game");
        }
    }

    private void OnMouseExit(){
        renderer.material.color = baseColor;
        objSelected = false;
    }
}
