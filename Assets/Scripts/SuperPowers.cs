using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SuperPowers : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PostProcessVolume _postProcessVolume;
    private Vignette _vignette;
    private IEnumerator _loop;
    
    void Start()
    {
        _postProcessVolume.profile.TryGetSettings(out _vignette);
        _loop = Change();
        
    }

    // Update is called once per frame
    void Update()
    {
        Invisible();
    }

    private void Invisible()
    {
        if (Input.GetButton("Jump"))
        {
            StartCoroutine(_loop);
        }
    }

    private IEnumerator Change()
    {
        float val = _vignette.intensity.value;
        if (val == 0)
        {
            while (_vignette.intensity.value > 0)
            {
                _vignette.intensity.value-=0.1f;
                yield return new WaitForSeconds(0.5f);
            }
            
        }
        else
        {
            while (_vignette.intensity.value < 1)
            {
                _vignette.intensity.value+=0.1f;
                yield return new WaitForSeconds(0.5f);
            }
            
        }
        
    }
}
