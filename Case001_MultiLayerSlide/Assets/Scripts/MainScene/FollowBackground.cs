using UnityEngine;
using System.Collections;

public class FollowBackground : MonoBehaviour {

	public Transform background;
	private float posDiffInX;
	private Vector3 posHelp;

	// Use this for initialization
	void Start () {
		posDiffInX = transform.position.x - background.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		posHelp.Set (background.position.x + posDiffInX,
		            transform.position.y, transform.position.z);
		transform.position = posHelp;
	}
}
