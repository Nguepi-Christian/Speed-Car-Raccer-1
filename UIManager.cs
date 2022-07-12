using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour {

	public Text live;
	public Text Coins;
	public GameObject PanelPause;
	public GameObject[] ListOfCars;
	string NameOfSelectedCar;

	public GameObject road;
	public GameObject PauseGameobject;
	public GameObject SpawnCoinObj;
	GameObject carselect;

	void Start(){
		PauseGameobject.SetActive (false);
		PanelPause.SetActive (false);

		NameOfSelectedCar = PlayerPrefs.GetString ("SelectedCar");

		for (int i=0; i<ListOfCars.Length; i++) {
			if(ListOfCars[i].transform.name==NameOfSelectedCar){
				ListOfCars[i].SetActive(true);
				carselect=ListOfCars[i];
				break;
			}
		}

		live.text = "" +carselect.GetComponent<CarControl>().GetCarLive();
		Coins.text = "" + carselect.GetComponent<CarControl>().GetCoinsValues();
	}

	void Update(){
		live.text = ""+carselect.GetComponent<CarControl>().GetCarLive();
		Coins.text = "" + carselect.GetComponent<CarControl>().GetCoinsValues();
	}

	public void Play(string nameoflevel){
		Application.LoadLevel (nameoflevel);
	}
	public void Home(){
		Application.LoadLevel("MainUI");
	}
	public void Pause(){
		PauseGameobject.SetActive (true);
		findAndPause ();
	}
	
	void findAndPause(){
		GameObject[] cars = GameObject.FindGameObjectsWithTag ("Cars");
		GameObject[] positions = GameObject.FindGameObjectsWithTag ("position");
		GameObject[] heart = GameObject.FindGameObjectsWithTag ("heart");
		GameObject[] coins = GameObject.FindGameObjectsWithTag ("Coins");

		PanelPause.SetActive (true);

		Time.timeScale = 0;
		SpawnCoinObj.GetComponent<CoinsSpawn> ().IsLoadBonus = false;
		carselect.GetComponent<AudioSource>().mute=true;
		carselect.GetComponent<CarControl> ().IsMove = false;
		carselect.GetComponent<Renderer>().sortingOrder=-1;
		road.GetComponent<Road> ().isMove = false;

		try{
			carselect.GetComponent<Animator> ().enabled = false;
		}catch(Exception e){
			//Debug.Log (e.Message);
		}
		for (int i=0; i<cars.Length; i++) {
			cars[i].GetComponent<SpawnCarControl>().ismove=false;
			cars[i].GetComponent<AudioSource>().mute=true;
			cars[i].GetComponent<Renderer>().sortingOrder=-1;
		}
		for (int i=0; i<positions.Length; i++) {
			positions[i].GetComponent<InstantiateCars>().IsInstantiateCars=false;
		}
		for (int i=0; i<heart.Length; i++) {
			heart[i].GetComponent<LiveBonus>().speed=0;
			heart[i].GetComponent<Renderer>().sortingOrder=-1;
		}
		for (int i=0; i<coins.Length; i++) {
			coins[i].GetComponent<LiveBonus>().speed=0f;
			coins[i].GetComponent<Renderer>().sortingOrder=-1;
		}
	}
	
	public void BackToGame(){
		PauseGameobject.SetActive (false);
		findAndPlay ();
	}
	void findAndPlay(){
		Time.timeScale = 1;
		GameObject[] cars = GameObject.FindGameObjectsWithTag ("Cars");
		GameObject[] positions = GameObject.FindGameObjectsWithTag ("position");
		GameObject[] heart = GameObject.FindGameObjectsWithTag ("heart");
		GameObject[] coins = GameObject.FindGameObjectsWithTag ("Coins");

		PanelPause.SetActive (false);

		SpawnCoinObj.GetComponent<CoinsSpawn> ().IsLoadBonus = true;
		road.GetComponent<Road> ().isMove = true;
		carselect.GetComponent<AudioSource>().mute=true;
		carselect.GetComponent<CarControl> ().IsMove = true;
		carselect.GetComponent<Renderer>().sortingOrder=0;

		try{
			carselect.GetComponent<Animator> ().enabled = true;
		}catch(Exception e){
			Debug.Log (e.Message);
		}

		for (int i=0; i<cars.Length; i++) {
			cars[i].GetComponent<SpawnCarControl>().ismove=true;
			cars[i].GetComponent<AudioSource>().mute=false;
			cars[i].GetComponent<Renderer>().sortingOrder=0;
		}
		for (int i=0; i<positions.Length; i++) {
			positions[i].GetComponent<InstantiateCars>().IsInstantiateCars=true;
		}
		for (int i=0; i<heart.Length; i++) {
			heart[i].GetComponent<LiveBonus>().speed=-0.01f;
			heart[i].GetComponent<Renderer>().sortingOrder=0;
		}
		for (int i=0; i<coins.Length; i++) {
			coins[i].GetComponent<LiveBonus>().speed=-0.1f;
			coins[i].GetComponent<Renderer>().sortingOrder=0;
		}
	}
	public void Restart(){
		Time.timeScale = 1;
		Application.LoadLevel ("RaceRoad");
	}
}
