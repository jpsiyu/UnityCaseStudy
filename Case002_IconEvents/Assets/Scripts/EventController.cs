using UnityEngine;
using System.Collections;

public class EventController : MonoBehaviour {

	public GameObject[] icons;
	// Use this for initialization
	void Start () {
		AddListener ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// add listener
	void AddListener(){
		for (int i=0; i<icons.GetLength(0); i++) {
			EventHandler ec = icons[i].GetComponent<EventHandler>();
			if(ec == null)
				icons[i].AddComponent<EventHandler>();
		}
	}

}
