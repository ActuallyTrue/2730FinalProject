using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
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
    public AudioSource radio;
    public AudioSource radioSound;
    public AudioSource paper;
    public AudioSource putItem;
    public AudioSource chairCreak;
    public GameObject reticle;
    Light light;
    
    // Start is called before the first frame update
    void Start()
    {
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
        paper = camera.transform.Find("paper").GetComponent<AudioSource>();
        radio = camera.transform.Find("radio").GetComponent<AudioSource>();
        radioSound = camera.transform.Find("radioSound").GetComponent<AudioSource>();
        putItem = camera.transform.Find("putItem").GetComponent<AudioSource>();
        chairCreak = camera.transform.Find("ChairCreak").GetComponent<AudioSource>();
        reticle = GameObject.FindWithTag("reticle");
        radioOn = true;
        radio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(objSelected){
            if(Input.GetKeyDown(KeyCode.Escape)){
                selObj.transform.position = basePos;
                selObj.transform.eulerAngles = baseRot;
                player.GetComponent<FirstPersonMovement>().enabled = true;
                camera.GetComponent<FirstPersonLook>().enabled = true;
                camera.transform.eulerAngles = camRot;
                looking = false;
                reticle.SetActive(true);
            }
        }
    }

    private void OnMouseEnter(){
        if(!looking){
            renderer.material.color = new Color(0.2f,1f,0.2f,0.3f);
        }
        objSelected = true;
        Debug.Log(renderer.material.color);
    }
    
    private void OnMouseDown(){
        if(objSelected && selObj.CompareTag("Poster")){
            putItem.Play();
            reticle.SetActive(false);
            renderer.material.color = baseColor;
            looking = true;
            holdingPos = player.transform.position + player.transform.TransformDirection(new Vector3(0,(player.transform.localScale.y) + 1.35f,1.5f));
            holdingRot = player.transform.eulerAngles;
            holdingRot.x *= 0.5f;
            holdingRot.y += 180;
            selObj.transform.position = holdingPos;
            selObj.transform.eulerAngles = holdingRot;
            player.GetComponent<FirstPersonMovement>().enabled = false;
            camRot = camera.transform.eulerAngles;
            camHoldingRot = camRot;
            camHoldingRot.x = 0;
            camera.transform.eulerAngles = camHoldingRot;
            camera.GetComponent<FirstPersonLook>().enabled = false;
        } else if(objSelected && selObj.CompareTag("rainSign")){
            putItem.Play();
            reticle.SetActive(false);
            renderer.material.color = baseColor;
            looking = true;
            holdingPos = player.transform.position + player.transform.TransformDirection(new Vector3(0,(player.transform.localScale.y) + 1.35f,3f));
            holdingRot = player.transform.eulerAngles;
            holdingRot.x *= 0.5f;
            holdingRot.y += 180;
            selObj.transform.position = holdingPos;
            selObj.transform.eulerAngles = holdingRot;
            player.GetComponent<FirstPersonMovement>().enabled = false;
            camRot = camera.transform.eulerAngles;
            camHoldingRot = camRot;
            camHoldingRot.x = 0;
            camera.transform.eulerAngles = camHoldingRot;
            camera.GetComponent<FirstPersonLook>().enabled = false;
        }else if(objSelected && selObj.CompareTag("paper")){
            reticle.SetActive(false);
            paper.Play();
            renderer.material.color = baseColor;
            looking = true;
            holdingPos = player.transform.position + player.transform.TransformDirection(new Vector3(0,(player.transform.localScale.y) + 1.35f,0.5f));
            holdingRot = player.transform.eulerAngles;
            holdingRot.x +=90;
            holdingRot.y += 180;
            selObj.transform.position = holdingPos;
            selObj.transform.eulerAngles = holdingRot;
            player.GetComponent<FirstPersonMovement>().enabled = false;
            camRot = camera.transform.eulerAngles;
            camHoldingRot = camRot;
            camHoldingRot.x = 0;
            camera.transform.eulerAngles = camHoldingRot;
            camera.GetComponent<FirstPersonLook>().enabled = false;
        } else if(objSelected && selObj.CompareTag("letter")){
            reticle.SetActive(false);
            paper.Play();
            renderer.material.color = baseColor;
            looking = true;
            holdingPos = player.transform.position + player.transform.TransformDirection(new Vector3(0,(player.transform.localScale.y) + 1.35f,1.5f));
            holdingRot = player.transform.eulerAngles;
            holdingRot.x +=90;
            holdingRot.y += 180;
            selObj.transform.position = holdingPos;
            selObj.transform.eulerAngles = holdingRot;
            player.GetComponent<FirstPersonMovement>().enabled = false;
            camRot = camera.transform.eulerAngles;
            camHoldingRot = camRot;
            camHoldingRot.x = 0;
            camera.transform.eulerAngles = camHoldingRot;
            camera.GetComponent<FirstPersonLook>().enabled = false;
        } else if(objSelected && selObj.CompareTag("frame")){
            putItem.Play();
            reticle.SetActive(false);
            renderer.material.color = baseColor;
            looking = true;
            holdingPos = player.transform.position + player.transform.TransformDirection(new Vector3(0,(player.transform.localScale.y) + 1.35f,1f));
            holdingRot = player.transform.eulerAngles;
            holdingRot.y += 180;
            selObj = GameObject.FindWithTag("picture");
            basePos = selObj.transform.position;
            baseRot = selObj.transform.eulerAngles;
            selObj.transform.position = holdingPos;
            selObj.transform.eulerAngles = holdingRot;
            player.GetComponent<FirstPersonMovement>().enabled = false;
            camRot = camera.transform.eulerAngles;
            camHoldingRot = camRot;
            camHoldingRot.x = 0;
            camera.transform.eulerAngles = camHoldingRot;
            camera.GetComponent<FirstPersonLook>().enabled = false;
        } else if(objSelected && selObj.CompareTag("lamp")){
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
                radio.volume = 0;
                radioOn = false;
                //play radio off sound
            } else {
                //set radio volume to 100 or base volume
                radioSound.Play();
                radio.volume = 0.1f;
                radioOn = true;
                //play radio on sound
            }
        } else if(objSelected && selObj.CompareTag("dreamChair")){
            chairCreak.Play();
            objSelected = false;
            SceneManager.LoadScene("Game");
        } else if(objSelected && selObj.CompareTag("awakeChair")){
            chairCreak.Play();
            objSelected = false;
            SceneManager.LoadScene("DreamNew");
        }
    }

    private void OnMouseExit(){
        renderer.material.color = baseColor;
        objSelected = false;
    }
}
