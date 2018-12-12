using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour {

    public Slider Volume;
    public AudioSource sound;
	// Update is called once per frame
	void Update () {
        sound.volume = Volume.value;
	}
}
