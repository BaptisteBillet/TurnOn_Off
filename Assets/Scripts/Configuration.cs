using UnityEngine;
using System.Collections;

public class Configuration : MonoBehaviour {

	public void configuration(int i)
	{
		PlayerPrefs.SetInt("Machine", i);
		Application.LoadLevel("game");
	}

}
