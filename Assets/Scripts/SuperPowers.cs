using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SuperPowers : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PostProcessVolume _postProcessVolume;
    private Vignette _vignette;
    void Start()
    {
        _postProcessVolume.profile.TryGetSettings(out _vignette);
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
            _vignette.intensity.value = 0;
        }
    }
}
