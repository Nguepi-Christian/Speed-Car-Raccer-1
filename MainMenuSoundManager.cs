using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MainMenuSoundManager : MonoBehaviour {

	public AudioSource BackGroundSound;
	public GameObject ButtonPlay;
	public GameObject ButtonStop;

	void Start(){}

	//Stop Soun Command
	public void StopSound(){
		ButtonPlay.SetActive (true);
		ButtonStop.SetActive (false);
		BackGroundSound.mute = true;
	}

	//Play sound command
	public void PlaySound(){
		ButtonPlay.SetActive (false);
		ButtonStop.SetActive (true);
		BackGroundSound.mute = false;
	}

}
