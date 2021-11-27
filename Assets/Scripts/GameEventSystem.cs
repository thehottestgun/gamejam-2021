using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameEventSystem Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = null;
        else
            Destroy(gameObject);
    }


    public event Action OnPlayerDead;
    
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
