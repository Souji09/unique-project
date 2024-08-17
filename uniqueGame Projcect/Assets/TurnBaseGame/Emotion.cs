using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Emotion : MonoBehaviour
{
    public static Emotion instance;

    public GameObject Player;
    public float EmotionStatus;
    public float EmotionStatusbar;
    public Slider Emotionbar;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        Unit PlayerUnit = GetComponent<Unit>();
    }
    private void Update()
    {
        Updatebar();
        
    }
    private void Updatebar()
    {
        if (EmotionStatus >= 100)
        {
            EmotionStatus = 100;
        }
        EmotionStatusbar = Mathf.Clamp(EmotionStatus, 0, 100);
        float EmotionCal = EmotionStatusbar / 100;
        Emotionbar.value = EmotionCal;
        EmotionEffect();
    }
    public void EmotionEffect()
    {
        if (EmotionStatus <= 40)
        {
            Emotionbar.fillRect.GetComponent<Image>().color = Color.yellow;
        }
        else if (EmotionStatus <= 60 && EmotionStatus >40)
        {
            Emotionbar.fillRect.GetComponent<Image>().color = Color.red;
        }
        else if (EmotionStatus <= 80 && EmotionStatus > 60)
        {
            Emotionbar.fillRect.GetComponent<Image>().color = Color.blue;
        }
        else if (EmotionStatus <= 40 && EmotionStatus > 80)
        {
            Emotionbar.fillRect.GetComponent<Image>().color = Color.gray;
        }      

    }
}


