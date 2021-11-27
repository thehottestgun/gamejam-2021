using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdate : MonoBehaviour
{
    public static UIUpdate instance;
    public TMPro.TMP_Text hp;
    public TMPro.TMP_Text cans;

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
    }

    public void SetHp(int number)
    {
        hp.text = number.ToString();
    }

    public void SetCans(int number)
    {
        cans.text = number.ToString();
    }
}
