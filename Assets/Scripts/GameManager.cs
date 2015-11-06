using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Video video, noise;
	public AudioClip noiseClip;
	
	float speedDecrease = 0.5f;
	float startTime = 0;
	float countPress = 0;
	float numPresses = 1;
	float lastMillis = 0;
	float startChangeTime = 0;
	bool onSexy = true;
	
	float sexyTime = 0;
	float unSexyTime = 0;

	AudioSource source;

	// Use this for initialization
	void Start () {
		startChangeTime = 1000000;
		resetVideo();
		if (gameObject.GetComponent<AudioSource> () == null)
			source = gameObject.AddComponent<AudioSource> ();
		else {
			source = gameObject.GetComponent<AudioSource> ();
		}
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

		
		if( countPress > 0 )
			countPress -= Time.deltaTime * speedDecrease;

		if(Time.time - startChangeTime > 5000){
			resetVideo();
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			countPress++;

			if(countPress >= numPresses){
				swapVideo();
				changeStarted();
			}
		}
	}
	
	private void changeStarted(){
		startChangeTime = Time.time;
	}
	private void swapVideo(){
		source.Play ();
		video.SwapVideo ();
		startTime = Time.time;
		countPress = 0;
		onSexy =!onSexy;
		
	}
	private void resetVideo(){

		startTime = Time.time-0.4f;
		video.RestartVideos ();
		noise.volume(0);
		//noise.gameObject.SetActive (false);
		startChangeTime = 1000000;
	}
}
