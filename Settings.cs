using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Settings : MonoBehaviour {

	public Text YouHaveHeartText;
	public Text YouHaveText;
	public Text NoMoney;

	public Text VolumeText;
	public Text HorizontalText;
	public Slider Volume;
	public Slider Horizontal;
	///
	int Coins;
	int Hearth;


	void Start () {
		VolumeText.text = "" + Volume.value;
		HorizontalText.text = "" + Horizontal.value;
		Coins = PlayerPrefs.GetInt ("Coins");
		Hearth = PlayerPrefs.GetInt ("Hearth");
		YouHaveText.text = "Your Money " + Coins;
		YouHaveHeartText.text = "You Have " + Hearth;

		if(Coins>=50)
			NoMoney.enabled = false;
	}


	void Update () {
		VolumeText.text = "" +100*(int)Volume.value;
		HorizontalText.text = "" + 100*(int)Horizontal.value;
		Coins = PlayerPrefs.GetInt ("Coins");
		Hearth = PlayerPrefs.GetInt ("Hearth");
		YouHaveText.text = "Your Money " + Coins;
		YouHaveHeartText.text = "You Have " + Hearth;

		if (Coins >= 50) {
			NoMoney.enabled = false;
		} else {
			NoMoney.enabled = true;
		}
	}

	public void buy(){
		Coins = PlayerPrefs.GetInt ("Coins");
		Hearth = PlayerPrefs.GetInt ("Hearth");

		if (Coins>=50 ) {
			Coins=Coins-50;
			Hearth++;
			PlayerPrefs.SetInt("Coins",Coins);
			PlayerPrefs.SetInt("Hearth",Hearth);
			NoMoney.enabled = false;
		}
		else{
			NoMoney.enabled = true;
		}
	}
}
