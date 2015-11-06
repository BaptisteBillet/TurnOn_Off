﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Video : MonoBehaviour
{
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


    protected IEnumerator StartStream ()
    {
		//KEEP IT HERE
		string sexVideo = "file://" + Application.streamingAssetsPath + "/coucou0001-0078.ogv";
		string platonicVideo = "file://" + Application.streamingAssetsPath + "/coucou0001-0078.ogv";
		string url;
		
		if (isSexVideoPlaying)
		{
			url = sexVideo;
		}
		else
		{
			url = platonicVideo;
		}
		
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
        //GetComponent<Renderer>().material.mainTexture = movieTexture;
    }
}
