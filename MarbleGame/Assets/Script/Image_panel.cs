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
                Title.text = "<뱀>";
                Discript.text = "...ㅋ";
                break;
            case "Ladder":
                Title.text = "<사다리>";
                Discript.text = "운이 좋으시군요~!!";
                break;
            default:
                ran = Random.Range(1, 101);

                if (ran > 90)
                {
                    Title.text = $"<{titles[0]}>";
                    Discript.text = discripts[0];
                }
                else if (ran > 75)
                {
                    Title.text = $"<{titles[1]}>";
                    Discript.text = discripts[1];
                }
                else if (ran > 60)
                {
                    Title.text = $"<{titles[2]}>";
                    Discript.text = discripts[2];
                }
                else if (ran > 45)
                {
                    Title.text = $"<{titles[3]}>";
                    Discript.text = discripts[3];
                }
                else if (ran > 30)
                {
                    Title.text = $"<{titles[4]}>";
                    Discript.text = discripts[4];
                }
                else
                {
                    Title.text = $"<{titles[5]}>";
                    Discript.text = discripts[5];
                }
                break;
        }

        
    }

    private void OnDisable()
    {
        switch (this.name)
        {
            case "Sneak":
                GameManager.Instance.drink_stack = 0;
                break;
            case "Ladder":
                GameManager.Instance.drink_stack++;
                break;
        }
        GameManager.Instance.Turn_start = true;
    }
}
