using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling : MonoBehaviour
{
    private Rigidbody rigid;
    private RaycastHit hit;

    public float power = 1;
    public float random;


    Coroutine coroutine;
    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
        rigid.isKinematic = true;
        
    }

    private void Awake()
    {
        
    }


    void Update()
    {
        if (rigid.velocity.x == 0 && rigid.velocity.z == 0)
        {
            if (Physics.Raycast(this.transform.position, transform.up, out hit, 2f))
            {
                GameManager.Instance.Dice_Num = 5;
                GameManager.Instance.Dice_num.gameObject.SetActive(true);
            }

            if (Physics.Raycast(this.transform.position, -1 * (transform.up), out hit, 2f))
            {
                GameManager.Instance.Dice_Num = 2;
                GameManager.Instance.Dice_num.gameObject.SetActive(true);
            }

            if (Physics.Raycast(this.transform.position, transform.forward, out hit, 2f))
            {
                GameManager.Instance.Dice_Num = 6;
                GameManager.Instance.Dice_num.gameObject.SetActive(true);
            }

            if (Physics.Raycast(this.transform.position, -1 * (transform.forward), out hit, 2f))
            {
                GameManager.Instance.Dice_Num = 1;
                GameManager.Instance.Dice_num.gameObject.SetActive(true);
            }

            if (Physics.Raycast(this.transform.position, transform.right, out hit, 2f))
            {
                GameManager.Instance.Dice_Num = 3;
                GameManager.Instance.Dice_num.gameObject.SetActive(true);
            }

            if (Physics.Raycast(this.transform.position, -1 * (transform.right), out hit, 2f))
            {
                GameManager.Instance.Dice_Num = 4;
                GameManager.Instance.Dice_num.gameObject.SetActive(true);
            }

            
        }
        

        
    }
}
