using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lightningTiming : MonoBehaviour
{
    public GameObject impact;
    public GameObject lightning;
    public AudioSource lightningSound;
    private bool triggered;
    private float start;
    private float totalTime;
    
    // Start is called before the first frame update
    void Start()
    {
        impact = GameObject.FindWithTag("impact");
        impact.SetActive(false);
        lightning = GameObject.FindWithTag("lightning");
        lightning.SetActive(false);
        lightningSound = GameObject.FindWithTag("lightningCrack").GetComponent<AudioSource>();
        triggered = false;
        start = Time.timeSinceLevelLoad;
        totalTime = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad >= start + 1f && triggered){
           lightning.SetActive(false);
           triggered = false; 
           impact.SetActive(false);
        }
        if(!triggered && Time.timeSinceLevelLoad > Random.Range(0,30) + totalTime + 30){
            start = Time.timeSinceLevelLoad;
            triggered = true;
            totalTime = Time.timeSinceLevelLoad;
            lightning.SetActive(true);
            impact.SetActive(true);
            lightningSound.Play();
        }
        if(Time.timeSinceLevelLoad > 240f && !triggered){
            start = Time.timeSinceLevelLoad;
            triggered = true;
            totalTime = Time.timeSinceLevelLoad;
            lightning.SetActive(true);
            impact.SetActive(true);
            lightningSound.Play();
            StartCoroutine(SceneChange());
        }
    }

    IEnumerator SceneChange(){
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene("AwakeNew");
    }
}
