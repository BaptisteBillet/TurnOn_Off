using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SoundManager : MonoBehaviour {
	#region Members

	[Header("PORNSTUFF")]
	public List<AudioClip> Porn = new List<AudioClip>();

	public AudioSource PornSource;


	#endregion

	// Use this for initialization
	void Start()
	{
		SoundManagerEvent.onEvent += Play;
	}

	void OnDestroy()
	{
		SoundManagerEvent.onEvent -= Play;
	}

	public void Play(SoundManagerType emt)
	{
		switch (emt)
		{
			case SoundManagerType.STARTPORNSOUND:
				PornSource.Stop();
				PornSource.volume = 0f;
				if (PlayerPrefs.GetInt("Machine") > 0 && PlayerPrefs.GetInt("Machine")<=5)
				{
					PornSource.clip = Porn[PlayerPrefs.GetInt("Machine") - 1];
				}

				PornSource.Play();
				break;

			case SoundManagerType.STOPPORNSOUND:
				{
					PornSource.Stop();
					StopAllCoroutines();
				}
				break;
		}
	}

	IEnumerator LouderAndLouder()
	{
		while(true)
		{
			yield return new WaitForSeconds(0.1f);
			PornSource.volume += 0.1f;
		}
	}
	

}