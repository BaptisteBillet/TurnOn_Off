using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager current;
	public Video video, noise;
	public AudioClip noiseClip;
	public Image blueBar, purpleBar;
	public Text blueText, purpleText;
	
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

	bool pornSoundPlaying;

	bool isGameMode=true;

	// Use this for initialization
	void Awake () {
		current = this;
		pornSoundPlaying = false;
		startChangeTime = 1000000;
		ResetVideo();
		if (gameObject.GetComponent<AudioSource> () == null)
			source = gameObject.AddComponent<AudioSource> ();
		else {
			source = gameObject.GetComponent<AudioSource> ();
		}

		int machineIndex = PlayerPrefs.GetInt ("Machine");
		video.prudeVideo = "prude" + machineIndex + ".ogv";
		video.sexyVideo = "sex" + machineIndex + ".ogv";
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Time.time - startTime > 10){
			
			if(pornSoundPlaying==false)
			{
				pornSoundPlaying = true;
				SoundManagerEvent.emit(SoundManagerType.STARTPORNSOUND);
			}
			
			if(onSexy){
				sexyTime += Time.deltaTime;
			}else{
				unSexyTime += Time.deltaTime;
			}
			
		}
		
		if (Time.time - startTime < 0.4f && !noise.gameObject.activeSelf) {
			noise.gameObject.SetActive (true);
			noise.RestartVideos();
			noise.gameObject.GetComponent<AudioSource>().Play();

		} else if(Time.time - startTime > 0.4f && noise.gameObject.activeSelf){
			noise.gameObject.SetActive (false);
		}


		/*
		if(Time.time - startChangeTime > 5){
			ResetVideo();
		}*/

		if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Start_1"))
		{
			ResetGame();
		}
		purpleText.text = "" + string.Format("{0:0}", unSexyTime);
		blueText.text = "" + string.Format("{0:0}", sexyTime);
		purpleBar.rectTransform.localScale = new Vector3 ((unSexyTime / 100f), 1, 1);
		blueBar.rectTransform.localScale = new Vector3 ((sexyTime / 100f), 1, 1);
		blueText.rectTransform.anchoredPosition = new Vector3 (blueBar.rectTransform.localScale.x * Screen.width * 0.5f + 10, -16, 0f);
		purpleText.rectTransform.anchoredPosition = new Vector3 (purpleBar.rectTransform.localScale.x * -Screen.width * 0.5f - 10, -16, 0f);

		if(Input.GetButtonDown("Back_1") || Input.GetKeyDown(KeyCode.E))
		{
			ChangeMode();
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

		pornSoundPlaying = false;
		SoundManagerEvent.emit(SoundManagerType.STOPPORNSOUND);
		
		
	}
	public void ResetGame() {
		video.RestartVideos();
		pornSoundPlaying = false;
		startTime = Time.time;
		startChangeTime = 1000000;
		unSexyTime = 0;
		sexyTime = 0;

	}
	public void ResetVideo() {

		startTime = Time.time-0.4f;
		video.RestartVideos ();
		noise.volume(0);
		//noise.gameObject.SetActive (false);
		startChangeTime = 1000000;
	}

	public void ChangeMode()
	{
		isGameMode = !isGameMode;
		blueBar.gameObject.SetActive(isGameMode);
		purpleBar.gameObject.SetActive(isGameMode);
		blueText.enabled = isGameMode;
		purpleText.enabled = isGameMode;
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