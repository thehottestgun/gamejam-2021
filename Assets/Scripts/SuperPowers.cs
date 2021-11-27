using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SuperPowers : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PostProcessVolume _postProcessVolume;
    private Vignette _vignette;
    private bool _toogle;
    
    
    void Start()
    {
        _postProcessVolume.profile.TryGetSettings(out _vignette);
        _toogle = true;

    }

    // Update is called once per frame
    void Update()
    {
        Invisible();
        
    }

    private void Invisible()
    {
        if (Input.GetButtonDown("SuperPower"))
        {
            if (_toogle)
            {
                _vignette.intensity.value = 1; 
                _toogle = false;
            }
            else
            {
                _vignette.intensity.value = 0; 
                _toogle = true;
            }
        }
    }

}
