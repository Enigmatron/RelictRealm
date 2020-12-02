using UnityEngine;
using System.Collections;

public class TPSCamera : MonoBehaviour {
	Vector3 angle;
	Vector3 Max = new Vector3(80,0,0);
	Vector3 Min = new Vector3(330f,0,0);
	public Vector3 curr;
	
	// Update is called once per frame
	void LateUpdate () {
		
		//if (merc.currentCameraMode.Equals (CameraMode.TPS) && merc.Status().Can_Look) {
		angle = new Vector3 (Input.GetAxis ("Mouse Y") * 1, 0, 0);
			
		transform.localEulerAngles -= angle;

		if (transform.localEulerAngles.x < Min.x && (transform.localEulerAngles.x > 180.0f))
			transform.localEulerAngles = Min;
		else if (transform.localEulerAngles.x > Max.x && !(transform.localEulerAngles.x > 180.0f))
			transform.localEulerAngles = new Vector3(Max.x, transform.localEulerAngles.y, transform.localEulerAngles.z);

		curr = transform.localEulerAngles;
//
	}

	void Awake()
	{
		//GetComponentInParent<ParagonLiveController>().ThirdPersonCamera = GetComponentInChildren<Camera>();
		//camera = this.gameObject.transform.GetChild(1).gameObject;
		//camera.transform = camera.transform;
	}

	///
	//if at 40º then rotate camera till 15º
	//if at 340º then rotate camera wil -15º
	//asperity
	///
}
