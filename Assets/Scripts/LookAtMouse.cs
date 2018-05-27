using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour {

	void LateUpdate () {
		//var dir = this.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
		var dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        Quaternion rot = this.transform.rotation;

        //Guckt nach links
        if (rot.eulerAngles.y < 180)
        {
            angle = -1 * (180-angle);
        }
        //Guckt nach rechts
        else
        {
            angle = -1 * angle;
        }


        rot = Quaternion.Euler(rot.eulerAngles.x, rot.eulerAngles.y, angle);
        this.transform.rotation = rot;
        //Debug.DrawRay(this.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position, Color.red);
	}
}