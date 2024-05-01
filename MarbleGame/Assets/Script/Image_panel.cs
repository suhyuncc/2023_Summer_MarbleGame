using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image_panel : MonoBehaviour
{
    [SerializeField]
    private string[] titles;
    [SerializeField]
    private string[] discripts;

    [SerializeField]
    private Text Title;
    [SerializeField]
    private Text Discript;

    private int ran;

    private void OnEnable()
    {
        switch (this.name)
        {
            case "Sneak":
                Title.text = "<��>";
                Discript.text = "...��";
                break;
            case "Ladder":
                Title.text = "<��ٸ�>";
                Discript.text = "���� �����ñ���~!!";
                break;
            default:
                ran = Random.Range(1, 101);

                if (ran > 90)
                {
                    Title.text = $"<{titles[0]}>";
                    Discript.text = discripts[0];
                }
                else if (ran > 60)
                {
                    Title.text = $"<{titles[1]}>";
                    Discript.text = discripts[1];
                }
                else if (ran > 30)
                {
                    Title.text = $"<{titles[2]}>";
                    Discript.text = discripts[2];
                }
                else
                {
                    Title.text = $"<{titles[3]}>";
                    Discript.text = discripts[3];
                }
                break;
        }

        
    }

    private void OnDisable()
    {
        GameManager.Instance.Turn_start = true;
    }
}
