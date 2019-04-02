using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource HoverSFX, ClickSFX, ExitSFX;

    public void PlayHoverSFX()
    {
        HoverSFX.Play();
    }

    public void PlayClickSFX()
    {
        ClickSFX.Play();
    }

    public void PlayExitSFX()
    {
        ExitSFX.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
