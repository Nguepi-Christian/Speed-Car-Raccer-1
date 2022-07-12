using UnityEngine;
using System.Collections;

public class SpawnCarControl : MonoBehaviour {
	public bool ismove=true;
	public float MoveSpeed;


	void Update () {
		if (ismove) {
			transform.Translate (new Vector3 (0,MoveSpeed, 0));
			Destroy(this.gameObject,10f);
		}
	}
}
