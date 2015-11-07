using UnityEngine;
using System.Collections;

public class Configuration : MonoBehaviour {

	public void configuration(int i)
	{
		PlayerPrefs.SetInt("Machine", i);
		Application.LoadLevel("game");
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			configuration(1);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			configuration(2);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			configuration(3);
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			configuration(4);
		}
		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			configuration(5);
		}

		if (Input.GetButtonDown("A_1"))
		{
			configuration(3);
		}
		if (Input.GetButtonDown("B_1"))
		{
			configuration(2);
		}
		if (Input.GetButtonDown("X_1"))
		{
			configuration(4);
		}
		if (Input.GetButtonDown("Y_1"))
		{
			configuration(1);
		}
		if (Input.GetButtonDown("RB_1"))
		{
			configuration(5);
		}

	}


}
