using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour {
	[SerializeField]private float Time;
	// Use this for initialization
	void Start () {
		StartCoroutine ("DestroyThis");
	}
	
	IEnumerator DestroyThis()
	{
		yield return new WaitForSeconds(Time);
		Destroy (this.gameObject);
	}
}
