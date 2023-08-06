using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public Transform Next;

    //[SerializeField]
    //private Image nodeImage;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player"
            && !other.gameObject.GetComponent<Player>().Ismove)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Player>().MoveNum--;
    }
}
