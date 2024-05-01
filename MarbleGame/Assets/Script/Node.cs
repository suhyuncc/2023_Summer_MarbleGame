using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public Transform Next;

    [SerializeField]
    private GameObject nodeImage;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player"
            && !other.gameObject.GetComponent<Player>().Ismove)
        {
            Debug.Log("hi");
            nodeImage.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Player>().MoveNum--;

        if (other.gameObject.GetComponent<Player>().MoveNum <= 0)
        {
            if(this.tag == "Event_node")
            {
                Debug.Log("hi");
            }
            
        }
    }
}
