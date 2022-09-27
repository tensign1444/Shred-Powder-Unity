using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    bool canMove = true;

    SurfaceEffector2D surfaceEffector2D;
    
    // Start is called before the first frame update
    void Start()
    {
       this.rb2d =  GetComponent<Rigidbody2D>();
       this.surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (canMove || !GetComponent<FinishLine>().finished) 
        {
            Rotate();
            Boost();
        }
        else
        {
            surfaceEffector2D.speed = 0;
            GetComponent<DustTrail>().GetTrail().Stop();
        }
       
    }

    /// <summary>
    /// Rotates our player
    /// </summary>
    private void Rotate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            rb2d.AddTorque(torqueAmount);
        else if (Input.GetKey(KeyCode.RightArrow)  || Input.GetKey(KeyCode.D))
            rb2d.AddTorque(-torqueAmount);
    }

    /// <summary>
    /// Sets can move = false;
    /// </summary>
    public void DisableMove()
    {
        canMove = false;
    }

    /// <summary>
    /// Boost the speed of our player
    /// </summary>
    private void Boost()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }

    }



}
