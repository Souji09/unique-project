using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOFFPanel : MonoBehaviour
{

    public GameObject Panel;
    public Button TurnOn;
    public Button TurnOff;
    void Start()
    {
        TurnOn.onClick.AddListener(ShowUp);
        TurnOff.onClick.AddListener(ShowUp);
    }

    public void ShowUp()
    {
        Panel.SetActive(!Panel.activeSelf);
    }
}
