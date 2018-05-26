using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;

	public float boundX = 1.5f;
	public float boundY = 0.5f;


	// Use this for initialization
	void Start()
	{
		
	}
	
	void LateUpdate()
	{
		Vector3 delta = Vector3.zero;

		float dx = target.position.x - this.transform.position.x;
		if (dx > boundX || dx < -boundX)
		{
			if (this.transform.position.x < target.position.x)
			{
				delta.x = dx - boundX;
			}
			else
			{
				delta.x = dx + boundX;
			}
		}

		float dy = target.position.y - this.transform.position.y;
		if (dy > boundY || dy < -boundY)
		{
			if (this.transform.position.y < target.position.y)
			{
				delta.y = dy - boundY;
			}
			else
			{
				delta.y = dy + boundY;
			}
		}
		
		this.transform.position = this.transform.position + delta;
	}

	void OnDrawGizmosSelected()
	{
		// Draw bounds
        // Gizmos.color = Color.red;
		// Gizmos.DrawWireCube(transform.position, new Vector3(6, 2, 2));
    }	
}
