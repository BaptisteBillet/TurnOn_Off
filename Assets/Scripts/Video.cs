using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Video : MonoBehaviour
{
	public string prudeVideo;
	public string sexyVideo;
    MovieTexture movieTexture;

	

	bool isSexVideoPlaying=true;

    void Start () 
	{
		StartCoroutine(StartStream());
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
		movieTexture.Stop();
		StopAllCoroutines();
		isSexVideoPlaying = !isSexVideoPlaying;
		Debug.Log ("Swap " + isSexVideoPlaying);
		StartCoroutine(StartStream());
	}
    protected IEnumerator StartStream ()
    {
		//KEEP IT HERE
		string sexVideo = "file://" + Application.streamingAssetsPath + "/" + sexyVideo; //"/coucou0001-0078.ogv";
		string platonicVideo = "file://" + Application.streamingAssetsPath + "/" + prudeVideo;//"/coucou0001-0078.ogv";
		string url;
		if (isSexVideoPlaying)
		{
			url = sexVideo;
		}
		else
		{
			url = platonicVideo;
		}
		Debug.Log ("StartStream 1 " + url);
		
		WWW videoStreamer = new WWW(url);


        movieTexture = videoStreamer.movie;
        GetComponent<AudioSource>().clip = movieTexture.audioClip;
        while (!movieTexture.isReadyToPlay) 
        {
            yield return 0;
		}
 
        GetComponent<AudioSource>().Play ();
        movieTexture.Play ();
        movieTexture.loop = true;
		GetComponent<RawImage>().texture = movieTexture;
		Debug.Log ("StartStream 2");
        //GetComponent<Renderer>().material.mainTexture = movieTexture;
    }
	public void RestartVideos()
	{
		StopAllCoroutines();
		StartCoroutine(StartStream());
	}
	public void volume(float vol)
	{
		GetComponent<AudioSource> ().volume = vol;
	} 
}
