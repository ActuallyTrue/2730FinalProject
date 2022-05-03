using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalMeteor : MonoBehaviour
{
    public void EndLevel()
    {
        SceneManager.LoadScene("AwakeNew");
    }
}
