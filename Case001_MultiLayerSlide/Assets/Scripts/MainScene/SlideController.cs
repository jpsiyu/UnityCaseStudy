using UnityEngine;
using System.Collections;

public class SlideController : MonoBehaviour {

	public Transform[] multiLayers;
	public float[] multiPositionRatios;
	public float moveTime;

	public float slideValue;

	private Vector3 helpPos;
	private Vector3 lastMouseInput;
	private Vector3 currentMouseInput;
	private bool draging;

	// Use this for initialization
	void Start () {
		draging = false;
	}
	
	// Update is called once per frame
	void Update () {
		// First, get slide value by mouse input
		ChangeSlideValueByMouseInput ();
		// Second, change position
		ChangePositionBySlideValue ();

	}

	void ChangePositionBySlideValue(){
		slideValue = Mathf.Clamp (slideValue, -10f, 10f);
		for(int i=0; i < multiLayers.GetLength(0); i++){
			helpPos.Set(slideValue * multiPositionRatios[i], 
			            multiLayers[i].position.y, multiLayers[i].position.z);
			multiLayers[i].position = Vector3.Lerp(multiLayers[i].position, helpPos, moveTime);
		}
	}

	void ChangeSlideValueByMouseInput(){
		if (Input.GetMouseButtonDown (0)) {
			lastMouseInput = Input.mousePosition;	
			draging = true;
		}
		if (Input.GetMouseButtonUp (0)) {
			lastMouseInput = Input.mousePosition;
			draging = false;		
		}
		if (draging) {
			currentMouseInput = Input.mousePosition;
			float diff = currentMouseInput.x - lastMouseInput.x;
			slideValue = (Mathf.Abs( diff) > 1) ? diff*0.1f : slideValue;
		}

	}

}
