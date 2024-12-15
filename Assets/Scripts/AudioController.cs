using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Sprite audio_on;                                                         // ������� "���� ���."
    public Sprite audio_off;                                                        // ������� "���� ����."
    public Slider audio_volume;                                                     // ������� ��������� �� ��������.
    public GameObject buttonAudio;                                                  // ������ ��������� ����� (��� ������������).

    public AudioClip clip;
    public AudioClip sound;
    public AudioSource source;

    public void Start()
    {
        source.clip = clip;
        source.Play();

        AudioListener.pause = true;
    }

    private void Update()
    {
        source.volume = audio_volume.value;                                         // ������ ��������� ������������� �������� �� slider.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioSource.PlayClipAtPoint(sound, Vector3.zero);
            AudioListener.pause = false;
        }
    }

    public void AudioStatus()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            buttonAudio.GetComponent<Image>().sprite = audio_off;
        }
        else
        {
            AudioListener.volume = 1;
            buttonAudio.GetComponent<Image>().sprite = audio_on;
        }
    }

    /// <summary>
    /// ����� ������� ����������.
    /// </summary>
    public void PlayAudio()
    {
        source.PlayOneShot(clip);                                                   // ������ ����������.
    }
}
