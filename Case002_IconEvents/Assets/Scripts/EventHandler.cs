using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class EventHandler : MonoBehaviour , IPointerClickHandler{

	public delegate void OnClick();
	public OnClick onClick;

	// Use this for initialization
	void Start () {
		AddDelegate ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void AddDelegate(){
		switch (this.name) {
		case "RawImageLT": onClick = this.RawImageLTOnClick; break;
		case "RawImageRT": onClick = this.RawImageRTOnClick; break;
		case "RawImageLB": onClick = this.RawImageLBOnClick; break;
		case "RawImageRB": onClick = this.RawImageRBOnClick; break;
		default: break;
		}
	}

	public void RawImageLTOnClick(){
		print ("RawImageLT");
	}
	public void RawImageRTOnClick(){
		print ("RawImageRT");
	}
	public void RawImageLBOnClick(){
		print ("RawImageLB");
	}
	public void RawImageRBOnClick(){
		print ("RawImageRB");
	}

	// when click
	public void OnPointerClick(PointerEventData eventData){
		if(onClick != null)
			onClick ();
	}
}
