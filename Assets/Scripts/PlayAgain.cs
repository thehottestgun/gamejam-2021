using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    public void ButtonLogic()
    {
        PlayerStats.StatReset();
        SceneManager.LoadScene(0);
    }
}
