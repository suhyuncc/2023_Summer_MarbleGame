using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice_Number : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine("Wait");
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.Dice_done = true;
    }
}
