using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Menu : MonoBehaviour
{
    private GameObject menu1;
    private GameObject menu2;

    [SerializeField] private TMPro.TMP_InputField playerName;
    private bool isNameOK = false;
    private bool isToggleOn = false;
    [SerializeField] private Toggle toggle;
    [SerializeField] private Button buttonStart;


    public void Start()
    {
        menu1 = GameObject.Find("Menu_1");
        menu2 = GameObject.Find("Menu_2");

        // aby na pewno sie nie pokazały na odwrót
        menu2.gameObject.SetActive(false);
        menu1.gameObject.SetActive(true);
    }
    public void goToMenu2()
    {
        menu1.gameObject.SetActive(false);
        menu2.gameObject.SetActive(true);
    }

    public void goBackToMenu1()
    {
        menu2.gameObject.SetActive(false);
        menu1.gameObject.SetActive(true);
    }

    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        PlayerStats.name = playerName.text;
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void checkName()
    {
        if (playerName.text.Length == 0)
        {
            playerName.image.color = new Color(1, 0.51f, 0.51f);
            isNameOK = false;
        }
        else if (!Regex.IsMatch(playerName.text, @"^[a-zA-Z]+$"))
        {
            playerName.image.color = new Color(1, 0.51f, 0.51f);
            isNameOK = false;
        }
        else
        {
            playerName.image.color = new Color(0.59f, 1, 0.6f);
            isNameOK = true;
        }

        ButtonLogic();
    }

    public void ToggleLogic()
    {
        if (toggle.isOn)
        {
            isToggleOn = true;
        }
        else
        {
            isToggleOn = false;
        }

        ButtonLogic();
    }

    public void ButtonLogic()
    {
        if (isToggleOn && isNameOK)
        {
            buttonStart.interactable = true;
        }
        else
        {
            buttonStart.interactable = false;
        }

    }



}

