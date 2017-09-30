using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip[] music;
    public AudioClip shotEnemy;
    public AudioClip shotPlayer;
    public AudioClip shotHit;
    public AudioClip explosion;
    private AudioSource audioSource;

    public void ShotPlayer()    { audioSource.PlayOneShot(shotPlayer, 0.1f);    }
    public void ShotEnemy()     { audioSource.PlayOneShot(shotEnemy, 1f);       }
    public void ShotHit()       { audioSource.PlayOneShot(shotHit, 3f);         }
    public void Explosion()     { audioSource.PlayOneShot(explosion, 1f);       }

    private void Awake()
    {
        if(GetComponent<AudioSource>() == null)
        {
            gameObject.AddComponent<AudioSource>();
        }
    }

    void Start () {
        audioSource = GetComponent<AudioSource>();
        if(music.Length > 0)
        {
            audioSource.loop = true;
            audioSource.volume = 0.5f;
        }
    }
	
	public void PlayTrack(int trackNumber)
    {
        audioSource.clip = music[trackNumber];
        audioSource.Play();
    }
}