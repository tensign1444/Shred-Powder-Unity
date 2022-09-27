using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem collisionEffect;
    [SerializeField] float BoostEmissionRate = 50f;
    [SerializeField] float BaseEmissionRate = 20f;
    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.tag == "Ground")
        {
            var emission = collisionEffect.emission;
            emission.rateOverTime = BaseEmissionRate;
            collisionEffect.Play();
        }
        else if (collision.gameObject.tag == "Ground" && Input.GetKey(KeyCode.LeftShift))
        {
            var emission = collisionEffect.emission;
            emission.rateOverTime = BoostEmissionRate;
            collisionEffect.Play();
        }

    }

    public ParticleSystem GetTrail()
    {
        return collisionEffect;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            collisionEffect.Stop();
        }
    }


}
