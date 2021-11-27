using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdate : MonoBehaviour
{
    public static UIUpdate instance;
    public TMPro.TMP_Text hp;
    public TMPro.TMP_Text cans;
    public TMPro.TMP_Text endInfo;

    public GameObject panel;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        hp.text = PlayerStats.playerHp.ToString();
        cans.text = PlayerStats.cans.ToString();
        endInfo.text = "";
        panel.SetActive(false);
    }

    public void SetHp(int number)
    {
        hp.text = number.ToString();
        
        if (number < 1)
        {
            panel.SetActive(true);
            endInfo.text = "LMAO YOU DIED XDDD";
        }
    }

    public void SetCans(int number)
    {
        cans.text = number.ToString();
    }
}
