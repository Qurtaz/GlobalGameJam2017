using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour {

    public AudioSource music;
    public AudioSource building;
    public AudioSource destroying;
    public AudioSource wave;
    public AudioSource money;

    //Muzyka
    public float volume;
    public bool mute;

    //SFX
    public float volumeSFX;
    public bool muteSFX;
    // Use this for initialization
    void Start () {
        music.loop = true;
        music.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SendVolumeMusic()
    {
        music.volume = music.volume * (volume / 100);
        music.mute = mute;
    }
    public void SendVolumeSFX()
    {
        music.volume = music.volume * (volume / 100);
        music.mute = mute;
        building.volume = music.volume * (volume / 100);
        building.mute = mute;
        destroying.volume = music.volume * (volume / 100);
        destroying.mute = mute;
        wave.volume = music.volume * (volume / 100);
        wave.mute = mute;
        money.volume = music.volume * (volume / 100);
        money.mute = mute;
    }
    public void PlayBuilding()
    {
        building.Play();
    }
    public void PlayDestrouy()
    {
        destroying.Play();
    }
    public void PlayMoney()
    {
        money.Play();
    }
    public void PlayeWave()
    {
        wave.Play();
    }
}
