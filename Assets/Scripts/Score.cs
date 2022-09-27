using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateText : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] Rigidbody rigidbody;
    float flipCounter2;
    float flipCounter1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckForFlip()
    {
        if ((player.transform.rotation.eulerAngles.z > zmin) && (player.transform.rotation.eulerAngles.z < zmax))
        {
           
        }
    }
}
