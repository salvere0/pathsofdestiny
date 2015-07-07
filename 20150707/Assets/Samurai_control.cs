using UnityEngine;
using System.Collections;

public class Samurai_control : MonoBehaviour {

	private Animator samiAnim;

	// Use this for initialization
	void Start () {
		samiAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Vertical") != 0) 
		{
			samiAnim.SetBool ("Walk", true);
		} 
		else 
		{
			samiAnim.SetBool("Walk", false);
		}
	}
}
