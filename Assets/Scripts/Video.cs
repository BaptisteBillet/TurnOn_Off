using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Video : MonoBehaviour
{
	private bool started = false;
	public string prudeVideo;
	public string sexyVideo;
	MovieTexture movieTexture1, movieTexture2;

	

	bool isSexVideoPlaying=true;

    void Start () 
	{
		if (!started) {

			StartCoroutine (StartStream1 ());
			StartCoroutine (StartStream2 ());
		}
		started = true;
    }
 
	void Update()
	{
		/*
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("space");
			/*
			movieTexture.Stop();
			StopAllCoroutines();
			isSexVideoPlaying = !isSexVideoPlaying;
			StartCoroutine(StartStream(isSexVideoPlaying));
			 * 
		}
		*/
	}

	public void SwapVideo ()
	{
		//movieTexture.Stop();
		//StopAllCoroutines();
		isSexVideoPlaying = !isSexVideoPlaying;
		//Debug.Log ("Swap " + isSexVideoPlaying);
		PlayVideo(isSexVideoPlaying);
		//StartCoroutine(StartStream());
	}
	protected IEnumerator StartStream1 ()
	{
		//KEEP IT HERE
		string video = "file://" + Application.streamingAssetsPath + "/" + sexyVideo; //"/coucou0001-0078.ogv";
		string url;
		
		
		WWW videoStreamer = new WWW(video);
		
		movieTexture1 = videoStreamer.movie;
		while (!movieTexture1.isReadyToPlay) 
		{
			yield return 0;
		}
		
		PlayVideo(true);
		movieTexture1.Play ();
		movieTexture1.loop = true;
	}
	protected IEnumerator StartStream2 ()
	{
		//KEEP IT HERE
		string video = "file://" + Application.streamingAssetsPath + "/" + prudeVideo; //"/coucou0001-0078.ogv";
		string url;
		
		
		WWW videoStreamer = new WWW(video);

		movieTexture2 = videoStreamer.movie;
		while (!movieTexture2.isReadyToPlay) 
		{
			yield return 0;
		}
		movieTexture2.Play ();
		movieTexture2.loop = true;
	}
	public void RestartVideos()
	{
		//StopAllCoroutines();
		//StartCoroutine(StartStream(true));
		//StartCoroutine(StartStream(false));
		//PlayVideo(isSexVideoPlaying);
		Debug.Log ("StopAllCoroutines ");
	}
	public void volume(float vol)
	{
		vol = Mathf.Clamp01 (vol);
		GetComponent<AudioSource> ().volume = vol;
	}
	void PlayVideo(bool sexyVideo){
		Debug.Log ("sexyVideo " + sexyVideo);
		if (sexyVideo) {
			if(movieTexture1.isPlaying)movieTexture1.Stop ();
			GetComponent<AudioSource>().clip = movieTexture1.audioClip;
			GetComponent<AudioSource>().Play ();
			GetComponent<RawImage>().texture = movieTexture1;
			movieTexture1.Play ();
			movieTexture1.loop = true;
		} else {
			if(movieTexture2.isPlaying)movieTexture2.Stop ();
			GetComponent<AudioSource>().clip = movieTexture2.audioClip;
			GetComponent<AudioSource>().Play ();
			GetComponent<RawImage>().texture = movieTexture2;
			movieTexture2.Play ();
			movieTexture2.loop = true;
		}
	}
	void OnDisable(){
		Debug.Log ("OnDisable");
	}
}
