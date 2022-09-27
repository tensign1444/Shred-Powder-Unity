using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem finishEffect;
    public bool finished = false;

    /// <summary>
    /// Triggered when player goes through finish line
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            finished = true;
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReLoadScene", delay);          
        }
        
    }


    private void ReLoadScene()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
