using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meteor : MonoBehaviour
{
    float deathTime = 7f;
    float timer;

    public AudioSource flyingSound;
    public AudioSource impactSound;
    // Start is called before the first frame update
    void Start()
    {
        flyingSound = GetComponent<AudioSource>();
        timer = deathTime;
        Destroy(this.gameObject, deathTime);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.layer == 7)
        {
            flyingSound.Stop();
            impactSound.Play();
        }
    }

    private void OnCollisionStay(Collision other) {
        if (other.gameObject.CompareTag("Player"))
        {
            impactSound.Play();
            PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
            if (player.invincible == false)
            {
                SceneManager.LoadScene("AwakeNew");
            }  
        }
    }
}
