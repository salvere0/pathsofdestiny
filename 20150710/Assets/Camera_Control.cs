using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Camera))]
public class Camera_Control : MonoBehaviour {

	[SerializeField] private float distance = 7f;
	[SerializeField] private float height = 5f;
	[SerializeField] private float heightDamping = 2f;
	[SerializeField] private float rotationDamping = 0f;

	public GameObject targetChar;

	void LateUpdate()
	{
		if (targetChar == null)
		{
			targetChar = GameObject.FindWithTag ("Player");
		} 
		else 
		{
			float targetRotationAngle = targetChar.transform.eulerAngles.y;
			float targetHight = targetChar.transform.position.y + height;

			float currentRotationAngle = transform.eulerAngles.y;
			float currentHight = transform.position.y;


			currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, targetRotationAngle, rotationDamping * Time.deltaTime);
			currentHight = Mathf.Lerp(currentHight, targetHight, heightDamping * Time.deltaTime);

			Quaternion currentRotation = Quaternion.Euler(0f,currentRotationAngle, 0f);

			transform.position = targetChar.transform.position;
			transform.position -= currentRotation * Vector3.forward * distance;

			transform.position = new Vector3(transform.position.x, currentHight, transform.position.z);
			transform.LookAt(targetChar.transform);
		}

	}
}