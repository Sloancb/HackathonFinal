using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class Combat : MonoBehaviour
{
    //Combat Features
    public float Player_Health = 100;
    public float Enemy_Health = 100;

    //Voice Features
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();


    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Battle Scene")
        {
            Debug.Log(SceneManager.GetActiveScene().name);

            actions.Add("Attack", Attack);
            actions.Add("Next", Next);

            keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
            keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
            keywordRecognizer.Start();
        }
    }

    void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    //Speech Functions
    void Attack()
    {
        Player_Damage(50);
    }
    void Next()
    {
        SceneManager.LoadSceneAsync("New Scene", LoadSceneMode.Single);
    }


    //UI Functions
    void Player_Damage(int acc)
    {
        
        Enemy_Health = Enemy_Health - acc;
        Debug.Log(Enemy_Health);
        if (Enemy_Health <= 0)
        {
            SceneManager.LoadSceneAsync("New Scene", LoadSceneMode.Single);
        }
    }
    void Enemy_Damage(int acc)
    {
        Player_Health = Player_Health - acc;
    }
}
