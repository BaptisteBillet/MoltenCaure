using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	#region Members

	//Clip
	public AudioClip musicClip;

	public AudioClip canonClip;
	public AudioClip rafaleClip;
	public AudioClip sniperClip;

	public AudioClip newWaveClip;
    public AudioClip fusion;

	public AudioClip interfaceClip;

	//Source
	public AudioSource cameraSource;
	public AudioSource newWaveSource;
	public AudioSource interfaceSource;
	public AudioSource tour;

	#endregion



	// Use this for initialization
	void Start()
	{
		SoundManagerEvent.onEvent += Effect;
		cameraSource.Stop();
		cameraSource.clip = musicClip;
		cameraSource.Play();
	}

	void OnDestroy()
	{
		SoundManagerEvent.onEvent -= Effect;
	}

	void Effect(SoundManagerType emt, GameObject emiter=null)
	{
		switch (emt)
		{
			case SoundManagerType.CANON:
				tour = emiter.GetComponent<AudioSource>();
				tour.Stop();
				tour.clip = canonClip;
				tour.Play();
				break;

			case SoundManagerType.RAFALE:
				tour = emiter.GetComponent<AudioSource>();
				tour.Stop();
				tour.clip = rafaleClip;
				tour.Play();
				break;

			case SoundManagerType.SNIPER:
				tour = emiter.GetComponent<AudioSource>();
				tour.Stop();
				tour.clip = sniperClip;
				tour.Play();
				break;

			case SoundManagerType.NEWWAVE:
				newWaveSource.Stop();
				newWaveSource.clip = newWaveClip;
				newWaveSource.Play();
				break;

			case SoundManagerType.INTERFACE:
				interfaceSource.Stop();
				interfaceSource.clip = interfaceClip;
				interfaceSource.Play();
				break;

            case SoundManagerType.FUSION:
                newWaveSource.Stop();
                newWaveSource.clip = fusion;
                newWaveSource.Play();
                break;

		}
	}

	

}
