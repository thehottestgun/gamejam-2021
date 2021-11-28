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
  


    void Start()
    {
        _postProcessVolume.profile.TryGetSettings(out _vignette);
        _toogle = 0;
        _isInvisible = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("SuperPower"))
        {
            if(PlayerStats.superPower==1) // Level 1
                Invisible();
            else if (PlayerStats.superPower == 2) // Level 2
                Teleportation();
            else return;
        }
        
    }

    private void Invisible()
    {
        if (_toogle == 0)
            StartCoroutine(ChangeUp());
        else
            StartCoroutine(ChangeDown());
    }

    public IEnumerator ChangeUp()
    {
        _toogle = -1;
        while (_vignette.intensity.value<=1)
        { 
            _vignette.intensity.value += vignetteSpeed; 
            yield return new WaitForSeconds(0.1f);
        }
        _toogle = 1;
        _isInvisible = true;
        StopCoroutine(ChangeUp());
            
    }

    public IEnumerator ChangeDown()
    {
        _toogle = -1;
        while (_vignette.intensity.value>=0)
        { 
            _vignette.intensity.value -= vignetteSpeed; 
            yield return new WaitForSeconds(0.1f);
        }
        _toogle = 0;
        _isInvisible = false;
        StopCoroutine(ChangeDown());
            
    }

    private void Teleportation()
    {
        
    }

}
