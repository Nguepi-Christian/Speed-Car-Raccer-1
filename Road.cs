using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Road : MonoBehaviour {

	public RawImage RoadBackground;
	public float SpeedFact;
	public bool isMove=true;

	void Start () {}
		
	void Update () {
		if (isMove) {
			RoadBackground.uvRect = new Rect (0,Time.time*SpeedFact,1,2.5f);
		} else {
			RoadBackground.uvRect = new Rect (0, 0, 1, 2.5f);
		}
	}
}
