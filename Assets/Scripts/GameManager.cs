using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager current;
	public Video video, noise;
	public AudioClip noiseClip;
	public Image bar;
	
	float speedDecrease = 0.5f;
	float startTime = 0;
	float countPress = 0;
	float numPresses = 10;
	float lastMillis = 0;
	float startChangeTime = 0;
	bool onSexy = true;
	
	float sexyTime = 0;
	float unSexyTime = 0;

	AudioSource source;

	// Use this for initialization
	void Awake () {
		current = this;
		startChangeTime = 1000000;
		ResetVideo();
		if (gameObject.GetComponent<AudioSource> () == null)
			source = gameObject.AddComponent<AudioSource> ();
		else {
			source = gameObject.GetComponent<AudioSource> ();
		}

		int machineIndex = PlayerPrefs.GetInt ("Machine")+1;
		video.prudeVideo = "prude" + machineIndex + ".ogv";
		video.sexyVideo = "sex" + machineIndex + ".ogv";
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - startTime > 10){
			if(onSexy){
				sexyTime = ((Time.time - startTime)-10);
			}else{
				unSexyTime = ((Time.time - startTime)-10);
			}
			
		}
		
		if (Time.time - startTime < 0.4f && !noise.gameObject.activeSelf) {
			noise.gameObject.SetActive (true);
			noise.RestartVideos();
			noise.gameObject.GetComponent<AudioSource>().Play();

		} else if(Time.time - startTime > 0.4f && noise.gameObject.activeSelf){
			noise.gameObject.SetActive (false);
		}



		if(Time.time - startChangeTime > 5000){
			ResetVideo();
		}

		if (Input.GetKeyDown (KeyCode.Return)) {
			video.RestartVideos();
		}

	}
	
	public void ChangeStarted(){
		startChangeTime = Time.time;
	}
	public void SwapVideo(){
		source.Play ();
		video.SwapVideo ();
		startTime = Time.time;
		countPress = 0;
		onSexy =!onSexy;
		
	}
	public void ResetVideo(){

		startTime = Time.time-0.4f;
		video.RestartVideos ();
		noise.volume(0);
		//noise.gameObject.SetActive (false);
		startChangeTime = 1000000;
	}

	
	void CheckForSexyController()
	{

	}

	bool DickOn()
	{

		return false;
	}

	bool DickOff()
	{
		return false;
	}


}

/* BUTTON
if (Input.GetButtonDown("A_1"))
{
    Debug.Log("A");
}
if (Input.GetButtonDown("B_1"))
{
    Debug.Log("B");
}
if (Input.GetButtonDown("X_1"))
{
    Debug.Log("X");
}
if (Input.GetButtonDown("Y_1"))
{
    Debug.Log("Y");
}
if (Input.GetButtonDown("Start_1"))
{
    Debug.Log("Start");
}
if (Input.GetButtonDown("Back_1"))
{
    Debug.Log("Select");
}
if (Input.GetButtonDown("LB_1"))
{
    Debug.Log("LB");
}
if (Input.GetButtonDown("RB_1"))
{
    Debug.Log("RB");
}
if (Input.GetAxis("DPad_XAxis_1")>0)
{
    Debug.Log("Pad droit");
}
if (Input.GetAxis("DPad_XAxis_1") < 0)
{
    Debug.Log("Pad gauche");
}
if (Input.GetAxis("L_XAxis_1") < 0)
{
    Debug.Log("Stick Gauche Gauche");
}
if (Input.GetAxis("L_XAxis_1") > 0)
{
    Debug.Log("Stick Gauche Droit");
}
if (Input.GetAxis("L_YAxis_1") < 0)
{
    Debug.Log("Stick Gauche Haut");
}
if (Input.GetAxis("L_YAxis_1") > 0)
{
    Debug.Log("Stick Gauche Bas");
}
if (Input.GetAxis("R_XAxis_1") < 0)
{
    Debug.Log("Stick Droit Gauche");
}
if (Input.GetAxis("R_XAxis_1") > 0)
{
    Debug.Log("Stick Droit Droit");
}
if (Input.GetAxis("R_YAxis_1") < 0)
{
    Debug.Log("Stick Droit Haut");
}
if (Input.GetAxis("R_YAxis_1") > 0)
{
    Debug.Log("Stick Droit Bas");
}
 
Debug.Log("Gachette Droite "+Input.GetAxis("TriggersR_1"));
Debug.Log("Gachette Gauche " + Input.GetAxis("TriggersL_1"));
*/