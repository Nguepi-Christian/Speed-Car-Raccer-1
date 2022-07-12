using UnityEngine;
using System.Collections;

public class MainUIManage : MonoBehaviour {

	public void Play(string nameoflevel){
		Application.LoadLevel (nameoflevel);
	} 

	public void Exit(){
		Application.Quit();
	} 
	public void OpenMyUrl(){
		Application.OpenURL("http://localhost/Rebcontre/Vue/");
	}
	public void BackToMenu(){
		Application.LoadLevel ("MainUI");	
	}

	public void selectCars(string carName){
		Application.LoadLevel ("RaceRoad");
		PlayerPrefs.SetString ("SelectedCar", carName);
	}
}
