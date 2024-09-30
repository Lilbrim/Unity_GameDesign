using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    // Start is called before the first frame update
    public float throwForce=40f;
    public GameObject Pipe_bomb;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            ThrowPipe_bomb();
        }
    }

    void ThrowPipe_bomb()
    {
        GameObject PipeBomb=Instantiate(Pipe_bomb, transform.position, transform.rotation);
        Rigidbody rb = PipeBomb.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward *throwForce, ForceMode.VelocityChange);
    }
}
