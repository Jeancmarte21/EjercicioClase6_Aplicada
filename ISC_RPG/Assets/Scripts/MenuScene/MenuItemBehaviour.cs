using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuItemBehaviour : MonoBehaviour
{
    const float _SCALEFACTOR = 1.2f;
    AudioManager _audioManager;
    private void Awake()
    {
        _audioManager = GameObject.Find("AudioManagerText").GetComponent<AudioManager>();
    }
    private void OnMouseEnter()
    {
        _audioManager.PlayHoverSFX();
        gameObject.transform.localScale *= _SCALEFACTOR;
    }

    private void OnMouseExit()
    {
        _audioManager.PlayExitSFX();
        gameObject.transform.localScale /= _SCALEFACTOR;
    }

    private void OnMouseUp()
    {
        _audioManager.PlayClickSFX();
        switch(gameObject.name)
        {
            case "MenuItemPlay":
                SceneManager.LoadScene("ExplorerLevel1Scene");
                break;
            case "MenuItemOptions":
                break;
            case "MenuItemCredits":
                break;
            case "MenuItemExit":
                Application.Quit();
                break;
        }
    }
}
