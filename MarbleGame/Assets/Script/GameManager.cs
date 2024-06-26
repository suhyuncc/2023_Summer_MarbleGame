using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject Dice;
    public GameObject Gage;
    public GameObject palyer_pool;
    public Text drink;
    private Coroutine coroutine;
    private GameObject cur_player;
    private Vector3 Dice_InitVec = Vector3.zero;
    private Quaternion Dice_InitQuat = Quaternion.identity;
    private int cur_player_index;
    public bool sliderUp;
    public int random;
    public float throughPower;
    public int Dice_Num;
    public int max_players;
    public int drink_stack;

    public bool Dice_done;
    public bool Turn_start;

    [Header("UI")]
    public Text Dice_num;
    public Text Slider_num;
    public Slider slider;

    void Start()
    {
        Instance = this;
        coroutine = StartCoroutine(Slider());
        cur_player_index = 0;
        drink_stack = 0;
        for (int i =0; i < max_players; i++)
        {
            palyer_pool.transform.GetChild(i).gameObject.SetActive(true);
        }
        //palyer_pool.transform.GetChild(0).gameObject.SetActive(true);
        cur_player = palyer_pool.transform.GetChild(0).gameObject;
    }

    private void Awake()
    {
        Dice.GetComponent<Rigidbody>().isKinematic = true;
        Dice_InitVec = Dice.transform.position;
        Dice_InitQuat = Dice.transform.rotation;
        Dice_done = false;
    }

    void Update()
    {
        if (Dice_done)
        {
            cur_player.GetComponent<Player>().MoveNum = Dice_Num;
            Dice_done = false;
            DiceReset();
        }

        if (Turn_start)
        {
            Gage.SetActive(true);
            coroutine = StartCoroutine(Slider());
            player_setting();
            Turn_start = false;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopCoroutine(coroutine);
            Gage.SetActive(false);
            random = Random.RandomRange(50, 1000);
            throughPower = 1 + 0.2f * ((int)(slider.value * 10) + 1);

            Dice.GetComponent<Rolling>().isroll = false;
            Dice.GetComponent<Rigidbody>().isKinematic = false;
            Dice.GetComponent<Rigidbody>().AddForce(new Vector3(1.7f, 0.7f, 1) * throughPower, ForceMode.Impulse);
            //Dice.GetComponent<Rigidbody>().AddTorque(new Vector3(1, 0, 1) * random, ForceMode.Impulse);
            Dice.GetComponent<Rigidbody>().angularVelocity = new Vector3(1, 0, 1) * random;
        }

        /*
        if (Input.GetKeyUp(KeyCode.R))
        {
            Dice.GetComponent<Rigidbody>().isKinematic = true;
            Dice.transform.position = Dice_InitVec;
            Dice.transform.rotation = Dice_InitQuat;
            Dice.GetComponent<Rolling>().isroll = true;
            Dice_Num = 0;
            Dice_num.gameObject.SetActive(false);
            Gage.SetActive(true);
            coroutine = StartCoroutine(Slider());
        }
        */

        Dice_num.text = Dice_Num.ToString();
        Slider_num.text = $"{(int)(slider.value * 10) +1}";
        drink.text = $"���� ��: {drink_stack}";
    }

    IEnumerator Slider()
    {
        slider.value = 0;
        sliderUp = true;
        while (true)
        {
            if (slider.value == 1)
            {
                sliderUp = false;
            }
            else if(slider.value == 0)
            {
                sliderUp = true;
            }

            if(sliderUp)
            {
                slider.value += 0.5f * Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }
            else
            {
                slider.value -= 0.5f * Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }
        }
    }

    private void DiceReset()
    {
        Dice.GetComponent<Rigidbody>().isKinematic = true;
        Dice.transform.position = Dice_InitVec;
        Dice.transform.rotation = Dice_InitQuat;
        Dice.GetComponent<Rolling>().isroll = true;
        Dice_Num = 0;
        Dice_num.gameObject.SetActive(false);
    }

    private void player_setting()
    {
        cur_player_index++;
        if (cur_player_index == max_players)
        {
            cur_player_index = 0;
        }
        cur_player = palyer_pool.transform.GetChild(cur_player_index).gameObject;

        if (cur_player.GetComponent<Player>().isFin)
        {
            player_setting();
        }
    }
}
