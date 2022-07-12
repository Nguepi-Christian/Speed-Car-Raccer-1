using UnityEngine;
using System.Collections;

public class LiveBonus : MonoBehaviour {

	public float speed=-0.01f;
	void Update(){
		transform.Translate (new Vector3 (0,speed, 0));
	}
	void OnTriggerEnter2D(Collider2D Obj){
		if (Obj.transform.tag == "Player") {
			Destroy(this.gameObject);
		}
	}
	
}
