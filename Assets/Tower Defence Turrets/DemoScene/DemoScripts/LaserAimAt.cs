using UnityEngine;
using System.Collections;

public class LaserAimAt : MonoBehaviour {

public Transform target;
public Transform tiltToAim;
public Transform panToAim;

	void Update() {
		
		panToAim.LookAt (target);        
		Vector3 newRotation = panToAim.eulerAngles;
		newRotation.x = newRotation.z = 0;
		panToAim.rotation = Quaternion.Euler (newRotation);


		tiltToAim.LookAt (target);
		Vector3 rotation = tiltToAim.localEulerAngles;
		rotation.y = rotation.z = 0;
		tiltToAim.localRotation = Quaternion.Euler (rotation);

	}
}
