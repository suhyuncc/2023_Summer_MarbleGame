using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public Transform Next;
    public GameObject Dest_node;

    [SerializeField]
    private GameObject nodeImage;

    public bool isDest;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player"
            && !other.gameObject.GetComponent<Player>().Ismove)
        {
            Debug.Log("hi");
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Player>().MoveNum--;

        if (other.gameObject.GetComponent<Player>().MoveNum <= 0)
        {
            if(this.tag == "Event_node")
            {
                nodeImage.SetActive(true);
            }
            else if (this.tag == "Move_node")
            {
                other.gameObject.GetComponent<Player>().Addposition = Dest_node.transform;
                other.gameObject.GetComponent<Player>().Addmove = true;
                Dest_node.GetComponent<Node>().isDest = true;


            }
            else if (this.tag == "Dest_node")
            {
                other.gameObject.GetComponent<Player>().Addmove = false;
                
                if (isDest)
                {
                    nodeImage.SetActive(true);
                    isDest = false;
                }
                else
                {
                    GameManager.Instance.Turn_start = true;
                }
                
            }


        }
    }
}
