using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public bool Ismove;
    public bool Addmove;
    public int MoveNum;

    public bool on_board;
    public bool isFin;
    private Transform lastposition;
    public Transform Addposition;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        on_board = false;
        isFin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(MoveNum <= 0)
        {
            Ismove = false;
        }
        else
        {
            Ismove = true;
        }

        if (Ismove)
        {
            if (!on_board)
            {
                this.transform.position = new Vector3(-9.25f, 0f, -10.7f);
                on_board = true;
            }
            else
            {
                this.transform.position = Vector3.MoveTowards(gameObject.transform.position, lastposition.position, 0.08f);
            }
            
        }

        if (Addmove)
        {
            this.transform.position = Vector3.MoveTowards(gameObject.transform.position, Addposition.position, 0.08f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        lastposition = other.gameObject.GetComponent<Node>().Next;
    }

    
}
