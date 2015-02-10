using UnityEngine;
using System.Collections;

public class LayerController : MonoBehaviour {

	public Transform[] multiLayers;
	public Transform backgroundLayer;
	public float[] layerRatios;
	public float bgBoundary;
	private float changeValue;

	private float backgroundStartPositionInX;
	private Vector3 helpPos;
	private float[] startPositionInXs;
	private bool drag;
	private float diff;

	// Use this for initialization
	void Start () {
		diff = 0f;
		drag = false;
		backgroundStartPositionInX = backgroundLayer.position.x;
		startPositionInXs = new float[multiLayers.GetLength (0)];
		for (int i = 0; i < multiLayers.GetLength(0); i++) {
			startPositionInXs[i]= multiLayers[i].position.x;	
		}
	}
	
	// Update is called once per frame
	void Update () {
		MoveBackground ();
		UpdateChangeValue ();
		UpdateMultiLayerPosition ();
	}

	void MoveBackground(){

		if (Input.GetMouseButtonDown (0)) {
			drag = true;	
			diff = backgroundLayer.position.x - Camera.main.ScreenToWorldPoint( Input.mousePosition).x;
		}
		if (Input.GetMouseButtonUp (0)) {
			drag = false;		
		}
		if (drag) {		

			helpPos.Set(Mathf.Clamp( Camera.main.ScreenToWorldPoint(Input.mousePosition).x + diff, -bgBoundary, bgBoundary),
			            backgroundLayer.position.y, backgroundLayer.position.z);
			backgroundLayer.position = helpPos;
		}
	}
	void UpdateChangeValue(){
		changeValue = backgroundLayer.position.x - backgroundStartPositionInX;
	}

	void UpdateMultiLayerPosition(){
		for (int i=0; i < multiLayers.GetLength(0); i++) {
			helpPos.Set(startPositionInXs[i]+changeValue*layerRatios[i],
			            multiLayers[i].position.y, multiLayers[i].position.z);
			multiLayers[i].position = helpPos;
		}
	}
}
