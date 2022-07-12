using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CarControl : MonoBehaviour {

	public float X_Speed;
	Vector2 direction=new Vector2();
	int carsLife=1;
	int CoinsValues=0;
	public Mode InputMode;
	public bool IsMove=true;

	int CoinsInMemory;
	int Haerth;
	void Start () {
		//PlayerPrefs.DeleteAll ();
		CoinsInMemory = PlayerPrefs.GetInt ("Coins");
		carsLife = carsLife + PlayerPrefs.GetInt ("Hearth");
	}
	void Update () {
		if (IsMove) {
			if (InputMode == Mode.Pc) {
				direction.x += X_Speed * Input.GetAxis ("Horizontal");
			}
			if (InputMode == Mode.Android) {
				direction.x += X_Speed * Input.acceleration.x;
			}
			direction.y = -3.82f;
			direction.x = Mathf.Clamp (direction.x, -2.76f, 2.76f);
			this.transform.position = direction;
		}
	}

	void OnTriggerEnter2D(Collider2D Obj){
		if (Obj.transform.tag == "heart") {
			carsLife++;
			PlayerPrefs.SetInt("Hearth",carsLife);
		}
		if (Obj.transform.tag == "Cars") {
			carsLife--;
			PlayerPrefs.SetInt("Hearth",carsLife);
			Destroy(Obj.gameObject);
			if(carsLife==0){
				Application.LoadLevel("GameOverMenu");
			}
		}
		if (Obj.transform.tag == "Coins") {
			CoinsValues++;
			Destroy(Obj.gameObject);
		}
		if (Obj.transform.tag == "Laser") {
			Destroy(Obj.gameObject);
		}
		PlayerPrefs.SetInt("Coins",CoinsValues+CoinsInMemory);
		PlayerPrefs.SetInt("CoinsTemp",CoinsValues);
		//print ("In memory "+PlayerPrefs.GetInt("Coins"));
		//print ("In memory temp"+PlayerPrefs.GetInt("CoinsTemp"));
	}

	//add a live to the this cars
	public void AddCarsLife(int lifeValue){
		this.carsLife = carsLife + lifeValue;
	}
	//get the car life for some initialization in other ways
	public int GetCarLive(){
		return this.carsLife;
	}
	public int GetCoinsValues(){
		return this.CoinsValues;
	}
	public enum Mode{
		Android,Pc
	}



}
