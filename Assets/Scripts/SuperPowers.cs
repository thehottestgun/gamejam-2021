using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;


public class SuperPowers : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PostProcessVolume _postProcessVolume;
    private Vignette _vignette;
    public float vignetteSpeed;
    private SpriteRenderer _sr;
    [SerializeField] private GameObject[] waypoints;
    private bool _spActive;


    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            PlayerStats.superPower = 1;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            PlayerStats.superPower = 2;
        }
    }

    void Start()
    {
        _postProcessVolume.profile.TryGetSettings(out _vignette);
        _sr = gameObject.GetComponent<SpriteRenderer>();
        _spActive = false;

    }
    
    // Update is called once per frame
    void Update()
    {
        if(PlayerStats.superPower  == 1)
            Invisible();
        if (PlayerStats.superPower == 2 && !_spActive)
            StartCoroutine("Teleportation");
        
    }

    private void Invisible()
    {
        StartCoroutine("ChangeUp");
    }

    public IEnumerator ChangeUp()
    {
        yield return new WaitForSecondsRealtime(3f);
        while (_vignette.intensity.value<=0.7)
        { 
            _vignette.intensity.value += vignetteSpeed; 
            yield return new WaitForSecondsRealtime(0.15f);
        }
        _sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, 0.5f);
        PlayerStats.isInvisible = true;
        StopCoroutine("ChangeUp");
            
    }
    private IEnumerator Teleportation()
    {
        _spActive = true;
        while (true)
        {
            yield return new WaitForSecondsRealtime(4f);
            System.Random rnd = new System.Random();
            var randTarget = rnd.Next(0, waypoints.Length);

            transform.position = new Vector3(waypoints[randTarget].transform.position.x,
                waypoints[randTarget].transform.position.y, transform.position.z); 
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            StopCoroutine("Teleportation");
        }
    }
}
