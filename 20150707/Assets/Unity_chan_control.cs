using UnityEngine;
using System.Collections;

public class Unity_chan_control : MonoBehaviour {

	private Animator unityAnim;
	// Use this for initialization
	void Start () {
		unityAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		unityAnim.SetBool ("Next", true);
	
	}
}
