using UnityEngine;
using System.Collections;

public class DestroyCars : MonoBehaviour {

	public bool ismove=true;
	public float MoveSpeed;

	void Update () {
		if (ismove) {
			transform.Translate (new Vector3 (0,MoveSpeed, 0));
			Destroy(this.gameObject,10f);
		}
	}


	void OnTriggerEnter2D(Collider2D Obj){

		if (Obj.transform.tag =="Cars") {

		}

	}
}
