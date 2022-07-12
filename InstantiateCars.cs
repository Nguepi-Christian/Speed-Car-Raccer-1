using UnityEngine;
using System.Collections;

public class InstantiateCars : MonoBehaviour {


	public GameObject[] ListOfCars;
	public bool IsInstantiateCars=true;
	public float RepeatRate;
	public float time;
	int RandomCars;

	void Start () {
		InvokeRepeating ("Spawn", time, RepeatRate);
	}
	

	void Update () {}

	void Spawn(){
		if (IsInstantiateCars) {
			RandomCars = Random.Range (0, ListOfCars.Length);
			Instantiate (ListOfCars [RandomCars], transform.position, Quaternion.identity);
		}
	}
}
