using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum Scenes
{
    Apartment = 1,
    Neighbourhood = 2,
    MetroRopucha = 3,
    MetroProper = 4,
    Krakow = 5,
    Farma = 6
}

public class FaderSceneProgress : MonoBehaviour
{
    public static bool progressToNextScene;
    [SerializeField] private Scenes nextScene;

    private void Start()
    {
        progressToNextScene = false;
        GetComponent<Animator>().SetBool("Fading",false);
    }

    // Start is called before the first frame update
    public void ChangeScene()
    {
        if (!progressToNextScene) return;
        SceneManager.LoadScene((int)nextScene);
    }
}
