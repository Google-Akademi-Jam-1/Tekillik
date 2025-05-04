using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0, 1f)]
    public float volume = .5f;

    [Range(-3f, 3f)]
    public float pitch = 1f;

}
