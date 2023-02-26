using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameDescription : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Example());
        SceneManager.LoadSceneAsync("Start Menu", LoadSceneMode.Single);
    }

    IEnumerator Example()
    {
      
        yield return new WaitForSeconds(5);
      
    }
}