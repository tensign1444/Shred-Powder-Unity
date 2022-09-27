using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem collisionEffect;
    [SerializeField] AudioClip crashSound;

    /// <summary>
    /// Checks if the user hit their head
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            FindObjectOfType<PlayerController>().DisableMove();
            collisionEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSound);
            Invoke("ReLoadScene", delay); 
        }
    }


    private void ReLoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
