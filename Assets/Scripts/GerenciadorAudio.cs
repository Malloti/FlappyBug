using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorAudio : MonoBehaviour
{
    public AudioSource sons;
    public static GerenciadorAudio inst = null;

    private void Awake()
    {
        if(inst == null)
        {
            inst = this;
        }else if(inst != null)
        {
            Destroy(gameObject);
        }
    }
}
