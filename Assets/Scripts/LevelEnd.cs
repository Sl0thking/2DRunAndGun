using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {
	
	void OnTriggerEnter(Collider other)
	{
		print("something entered");
	}

	void OnTriggerStay(Collider other)
	{
		print("something is staying");
	}

	void OnTriggerExit(Collider other)
	{
		print("something exited");
	}
}
