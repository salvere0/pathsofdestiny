using UnityEngine;
using System.Collections;

public class CubeRotate : MonoBehaviour {
	//public float speed;
	//Vector3 rotVec;

	private HingeJoint hingeJoint;
	private JointMotor moter;
	// Use this for initialization
	void Start () {
	//	speed = 10.0f;
	//	rotVec = Vector3.zero;

		hingeJoint = GetComponent<HingeJoint> ();
		moter = new JointMotor ();
		moter.force = 100;
	}
	
	// Update is called once per frame
	//void Update () {
		//rotVec += Vector3.up * speed * Time.deltaTime;
		//transform.rotation = Quaternion.Euler(rotVec);

	//}

	void FixedUpdate(){
		if(Input.GetKey(KeyCode.Z)){
			moter.targetVelocity = 360.0f;
			hingeJoint.motor = moter;
		} else{
			moter.targetVelocity = -360.0f;
			hingeJoint.motor = moter;
		}
	}
}
