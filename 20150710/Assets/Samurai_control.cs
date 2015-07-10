using UnityEngine;
using System.Collections;

public class Samurai_control : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Vertical") != 0) {
			anim.SetFloat("Forward", Input.GetAxis ("Vertical"));
		}
		if (Input.GetAxis ("Horizontal") != 0) 
		{
			anim.SetFloat("Direction", Input.GetAxis("Horizontal"));
		}
	
	}
}
