using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUp : MonoBehaviour
{
    // Start is called before the first frame update
    // Used to choose correct window
    void Start()
    {
        Debug.Log("Startup");
        SceneManager.LoadSceneAsync("Start Menu", LoadSceneMode.Single);
        SceneManager.UnloadSceneAsync("GameDescriptionScene");
        SceneManager.UnloadSceneAsync("New Scene");
    }

}
