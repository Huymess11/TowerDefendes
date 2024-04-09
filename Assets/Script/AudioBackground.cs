using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBackground : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource music;
    public AudioClip musicBg;

    // Update is called once per frame
    void Start()
    {
        music.clip = musicBg;
        music.loop = true;
        music.Play();
    }
}
