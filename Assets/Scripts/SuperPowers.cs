using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;



public class SuperPowers : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PostProcessVolume _postProcessVolume;
    private Vignette _vignette;
    public float vignetteSpeed;
    private int _toogle;
    private bool _isInvisible;
    private SpriteRenderer _sr;
    [SerializeField] private GameObject[] waypoints;

  


    void Start()
    {
        _postProcessVolume.profile.TryGetSettings(out _vignette);
        _toogle = 0;
        _isInvisible = false;
        _sr = gameObject.GetComponent<SpriteRenderer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Invisible();
        if (Input.GetButtonDown("SuperPower"))
        {
            if (PlayerStats.superPower == 2) // Level 2
                Teleportation();
            else return;
        }
        
    }

    private void Invisible()
    {
        StartCoroutine(ChangeUp());
        // else
        //     StartCoroutine(ChangeDown());
    }

    public IEnumerator ChangeUp()
    {
        _toogle = -1;
        while (_vignette.intensity.value<=0.7)
        { 
            _vignette.intensity.value += vignetteSpeed; 
            yield return new WaitForSeconds(0.1f);
        }
        _sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, 0.5f);
        PlayerStats.isInvisible = true;
        StopCoroutine(ChangeUp());
            
    }

    // public IEnumerator ChangeDown()
    // {
    //     _toogle = -1;
    //     while (_vignette.intensity.value>=0)
    //     { 
    //         _vignette.intensity.value -= vignetteSpeed; 
    //         yield return new WaitForSeconds(0.1f);
    //     }
    //     _toogle = 0;
    //     PlayerStats.isInvisible = false;
    //     StopCoroutine(ChangeDown());
    //         
    // }

    private void Teleportation()
    {
        System.Random rnd = new System.Random();
        var randTarget = rnd.Next(0, waypoints.Length);

        transform.position = new Vector3(waypoints[randTarget].transform.position.x,
            waypoints[randTarget].transform.position.y, transform.position.z);
        

    }

}
