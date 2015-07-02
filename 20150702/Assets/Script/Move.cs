using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	private Transform testMove;

	private bool direction = true;

	public float speed;
	// Use this for initialization
	void Start () {
		testMove = GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (direction)
		{
					testMove.Translate (new Vector3 (0.0f, 0.0f, -1.0f) * (speed * Time.deltaTime));
					if (testMove.position.z <= -2.3f) 
						{
								direction = false;
						}
		}
		else
		{
			testMove.Translate (new Vector3 (0.0f, 0.0f, 1.0f) * (speed * Time.deltaTime));
			if (testMove.position.z >= -1.6f)
			{
				direction = true;
			}
		}
	
	}
}
