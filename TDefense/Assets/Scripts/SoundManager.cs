using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioSource> audios;
    public GameObject mutedIcon;

    public int muted = 0;

    // Start is called before the first frame update
    void Start()
    {
        muted = PlayerPrefs.GetInt("muted", 0);

        CheckIfMuted();

    }

    public void ToggleMute()
    {
        if (muted == 0)
        {
            muted = 1;
            mutedIcon.SetActive(true);
        }
        else if(muted == 1)
        {
            muted = 0;
            mutedIcon.SetActive(false);
        }
        PlayerPrefs.SetInt("muted", muted);

        CheckIfMuted();
    }

    public void CheckIfMuted()
    {
        if (muted == 1)
        {
            foreach (AudioSource audio in audios)
            {
                audio.mute = true;
            }
            mutedIcon.SetActive(true);
        }
        else
        {
            foreach (AudioSource audio in audios)
            {
                audio.mute = false;
            }
            mutedIcon.SetActive(false);
        }
    }
}
