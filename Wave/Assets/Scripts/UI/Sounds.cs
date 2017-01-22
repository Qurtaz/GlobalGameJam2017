using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sounds : MonoBehaviour {

    public AudioSource music;
    public AudioSource building;
    public AudioSource destroying;
    public AudioSource wave;
    public AudioSource money;
    public AudioSource alter;

    public Slider musicSlider;
    public Toggle musicToggler;

    public Slider SFXSlider;
    public Toggle SFXToggler;

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
        LevelEvents.StartLevel += PlayAlter;
        LevelEvents.EndLevel += StopWave;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void saveMusic()
    {
        volume = musicSlider.value;
        mute = !musicToggler.isOn;
        SendVolumeMusic();
    }
    public void saveSFX()
    {
        volumeSFX = SFXSlider.value;
        muteSFX = !SFXToggler.isOn;
        SendVolumeSFX();
    }
    public void SendVolumeMusic()
    {
        music.volume = volume * (volume / 100);
        music.mute = mute;
    }
    public void SendVolumeSFX()
    {
        alter.volume = volumeSFX * (volume / 100);
        alter.mute = muteSFX;
        building.volume = volumeSFX * (volume / 100);
        building.mute = muteSFX;
        destroying.volume = volumeSFX * (volume / 100);
        destroying.mute = muteSFX;
        wave.volume = volumeSFX * (volume / 100);
        wave.mute = muteSFX;
        money.volume = volume * (volume / 100);
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
    public void PlayeWave()//
    {
        wave.loop = true;
        wave.Play();
    }
    public void  PlayAlter()//
    {
        alter.Play();
        Invoke("PlayAlterSe", 5);
    }
    private void PlayAlterSe()
    {
        alter.Play();
    }
    public void StopWave()
    {
        wave.Stop();
    }
}
