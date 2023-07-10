using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling : MonoBehaviour
{
    private Rigidbody rigid;
    public float power = 1;
    private float random;


    Coroutine coroutine;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.isKinematic = true;
    }

    private void Awake()
    {
        //coroutine = StartCoroutine(spin());
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            random = Random.RandomRange(50, 100);
            //StopCoroutine(coroutine);
            rigid.isKinematic = false;
            rigid.AddForce(new Vector3(1, 0.7f, 1) * power, ForceMode.Impulse);
            rigid.AddTorque(new Vector3(1, 0, 1) * random, ForceMode.Impulse);
        }
    }

    IEnumerator spin()
    {
        while (true)
        {
            this.transform.Rotate(1, 0, 1);
            yield return null;
        }
    }
}
