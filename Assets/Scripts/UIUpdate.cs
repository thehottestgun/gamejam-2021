using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdate : MonoBehaviour
{
    public static UIUpdate instance;
    public Text hp;
    public Text cans;

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

    public void SetHp(int number)
    {
        hp.text = number.ToString();
    }

    public void SetCans(int number)
    {
        cans.text = number.ToString();
    }
}
