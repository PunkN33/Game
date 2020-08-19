using UnityEngine;
using System.Collections;

public class TimeDestroy : MonoBehaviour {
	public float TimeStart;
	public float TimeEnd;
	public float SpeedTime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		TimeStart += SpeedTime;
		if (TimeStart >= TimeEnd) {
			gameObject.SetActive (false);
		}
	}
}
