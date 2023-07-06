using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling : MonoBehaviour
{
    private Rigidbody rigid;
    public float power = 1;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.isKinematic = true;
    }

    
    void Update()
    {
        this.transform.Rotate(1, 0, 1);
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rigid.isKinematic = false;
            rigid.AddForce(new Vector3(1, 0.7f, 1) * power, ForceMode.Impulse);
            //rigid.AddForce(new Vector3(0.6f, 0.6f, 0) * power, ForceMode.Impulse);
            
        }
    }

}
