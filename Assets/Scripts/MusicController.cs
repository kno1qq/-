using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public AudioSource BGM_audioSource;
    public AudioSource SFX_audioSource;
    public Slider BGM_slider;
    public Slider SFX_slider;
    // Start is called before the first frame update
    void Start()
    {
        BGM_slider.value = 0.5f;
        SFX_slider.value=0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        BGM_audioSource.volume =BGM_slider.value;
        SFX_audioSource.volume =SFX_slider.value;
    }
}
