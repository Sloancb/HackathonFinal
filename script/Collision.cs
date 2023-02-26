using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Used to trigger next slide
// Marvin collides with object
public class Collision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        SceneManager.LoadSceneAsync("Battle Scene", LoadSceneMode.Single);
    }
}
