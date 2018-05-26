using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour {

	void Update () {
		//var dir = this.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//var dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
		//var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

		print(this.transform.rotation.eulerAngles);
		// this.transform.rotation = Quaternion.Euler(0, this.transform.rotation.y < 0 ? 180 : 0, angle * -1);
		//this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		Debug.DrawRay(this.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position, Color.red);
	}
}