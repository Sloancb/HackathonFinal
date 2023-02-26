using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private Scene scene;
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    
    // Start is called before the first frame update
    
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Start Menu")
        {
            actions.Add("Two", loadGameDescriptionScene);
            actions.Add("One", loadNewScene);

            keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
            keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
            keywordRecognizer.Start();

            Debug.Log(SceneManager.GetActiveScene().name);
            Debug.Log(" is currently running.");
        }
    }
    

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }
    void loadGameDescriptionScene()
    {
        Debug.Log("Options");
        SceneManager.LoadSceneAsync("GameDescriptionScene", LoadSceneMode.Single);
    }
    void loadNewScene()
    {
        Debug.Log("Start");
        SceneManager.LoadSceneAsync("New Scene", LoadSceneMode.Single);
    }

    /* private void Awake()
     {
         // It is save to remove listeners even if they
         // didn't exist so far.
         // This makes sure it is added only once
         SceneManager.sceneLoaded -= OnSceneLoaded;

         // Add the listener to be called when a scene is loaded
         SceneManager.sceneLoaded += OnSceneLoaded;

         DontDestroyOnLoad(gameObject);

         // Store the creating scene as the scene to trigger start
         scene = SceneManager.GetActiveScene();
     }*/

    private void OnDestroy()
    {
        // Always clean up your listeners when not needed anymore
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Listener for sceneLoaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // return if not the start calling scene
        if (!string.Equals(scene.path, this.scene.path)) return;

        //SceneManager.UnloadSceneAsync("Start Menu");
        
    }
}

