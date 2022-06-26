using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSFX : MonoBehaviour
{
    [SerializeField]AudioSource toggleSFX;

    public void PlayToggleSFX()
    {
        toggleSFX.Play();
    }
}
