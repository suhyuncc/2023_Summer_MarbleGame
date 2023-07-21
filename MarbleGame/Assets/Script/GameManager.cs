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
    private Coroutine coroutine;
    private Vector3 Dice_InitVec = Vector3.zero;
    private Quaternion Dice_InitQuat = Quaternion.identity;
    public bool sliderUp;
    public int random;
    public float throughPower;
    public int Dice_Num;

    [Header("UI")]
    public Text Dice_num;
    public Text Slider_num;
    public Slider slider;

    void Start()
    {
        Instance = this;
        coroutine = StartCoroutine(Slider());
    }

    private void Awake()
    {
        Dice.GetComponent<Rigidbody>().isKinematic = true;
        Dice_InitVec = Dice.transform.position;
        Dice_InitQuat = Dice.transform.rotation;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopCoroutine(coroutine);
            Gage.SetActive(false);
            random = Random.RandomRange(50, 1000);
            throughPower = 1 + 0.2f * ((int)(slider.value * 10) + 1);

            Dice.GetComponent<Rigidbody>().isKinematic = false;
            Dice.GetComponent<Rigidbody>().AddForce(new Vector3(1.7f, 0.7f, 1) * throughPower, ForceMode.Impulse);
            //Dice.GetComponent<Rigidbody>().AddTorque(new Vector3(1, 0, 1) * random, ForceMode.Impulse);
            Dice.GetComponent<Rigidbody>().angularVelocity = new Vector3(1, 0, 1) * random;
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            Dice.GetComponent<Rigidbody>().isKinematic = true;
            Dice.transform.position = Dice_InitVec;
            Dice.transform.rotation = Dice_InitQuat;
            Dice_Num = 0;
            Dice_num.gameObject.SetActive(false);
            Gage.SetActive(true);
            coroutine = StartCoroutine(Slider());
        }

        Dice_num.text = Dice_Num.ToString();
        Slider_num.text = $"{(int)(slider.value * 10) +1}";
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
                slider.value += 0.3f * Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }
            else
            {
                slider.value -= 0.3f * Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }
        }
    }
}
