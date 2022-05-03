using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalMeteor : MonoBehaviour
{
    AudioSource impact;

    private void Start() {
        impact = GetComponent<AudioSource>();
    }

    public void PlayImpact()
    {
        impact.Play();
    }

    public void EndLevel()
    {
        SceneManager.LoadScene("AwakeNew");
    }
}
