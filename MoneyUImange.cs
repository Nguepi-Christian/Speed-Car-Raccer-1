using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyUImange : MonoBehaviour {

	public Text CoinsCollect;
	public Text TotalCoins;

	void Start () {
		CoinsCollect.text = "+" + PlayerPrefs.GetInt ("CoinsTemp");
		TotalCoins.text = "" + PlayerPrefs.GetInt ("Coins");
	}
}
