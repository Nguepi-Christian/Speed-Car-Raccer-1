using UnityEngine;
using System.Collections;

public class CoinsSpawn : MonoBehaviour {

	public Transform[] CoinsPos;
	public GameObject[] CoinsList;
	public float time;
	public float rate;
	public bool IsLoadBonus=true;
	public float[] Probability;
	int randomPos,randombonus;


	void Start () {
		InvokeRepeating ("SpawnCoins", 1, 10);
	}
	
	// Update is called once per frame

	void SpawnCoins(){
		if (IsLoadBonus) {
			randomPos = Random.Range (0, CoinsPos.Length);
			randombonus = (int)Choose (Probability);
			Instantiate (CoinsList[randombonus], CoinsPos [randomPos].position, Quaternion.identity);
		}

	}



	//
	float Choose (float[] probs) {
		
		float total = 0;
		
		foreach (float elem in probs) {
			total += elem;
		}
		
		float randomPoint = Random.value * total;
		
		for (int i= 0; i < probs.Length; i++) {
			if (randomPoint < probs[i]) {
				return i;
			}
			else {
				randomPoint -= probs[i];
			}
		}
		return probs.Length - 1;
	}
}
