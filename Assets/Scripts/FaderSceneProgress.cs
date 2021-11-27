using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum Scenes
{
    Apartment = 1,
    Neighbourhood = 2,
    MetroRopucha1 = 3,
    MetroRopucha2 = 4,
    MetroProper = 5,
    Krakow = 6,
    Farma = 7
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
