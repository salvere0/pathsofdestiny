using UnityEngine;
using System.Collections;

public class BGScroll : MonoBehaviour {
	Transform[] backGrounds;
	[SerializeField]private float speed = 3f;
	// Use this for initialization
	void Start () {
		backGrounds = GameObject.FindWithTag ("BackGround").GetComponents<Transform> ();

	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < backGrounds.Length; ++i) {
			backGrounds[i].Translate(Vector3.right * speed * Time.deltaTime);
		}
	}
}
