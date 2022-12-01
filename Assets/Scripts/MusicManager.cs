using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] Songs;

    private int SongCount;
    private float MusicVolume;

    private void Awake()
    {
    }
    private void Start()
    {
        SongCount = Random.Range(0, Songs.Length);
        MusicVolume = GameManager.GM.MusicVolume / 100;
    }

    private void Update()
    {
        MusicVolume = GameManager.GM.MusicVolume / 100;

        GetComponent<AudioSource>().volume = MusicVolume;

        if (GetComponent<AudioSource>().isPlaying == false)
        {
            SongCount++;
            if (SongCount >= Songs.Length)
            {
                SongCount = 0;
            }
            GetComponent<AudioSource>().clip = Songs[SongCount];

            GetComponent<AudioSource>().Play();
        }
    }
}
