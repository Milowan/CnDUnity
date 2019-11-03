﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void setVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

}
