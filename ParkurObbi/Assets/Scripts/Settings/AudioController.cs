using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField, Header("������� ������: ")] private Slider SliderMusic;
    [SerializeField, Header("������� ������: ")] private Slider SliderSound;
    
    [SerializeField, Header("������: ")] private AudioSource SourceMusic;
    [SerializeField, Header("����: ")] private AudioSource SourceSound;

    [SerializeField, Header("������ ���/���� ������: ")] private Sprite[] SpriteMusic;
    [SerializeField, Header("������ ���/���� ����: ")] private Sprite[] SpriteSound;

    [SerializeField, Header("�������� ������: ")] private Image ImageMusic;
    [SerializeField, Header("�������� ����: ")] private Image ImageSound;

    public void Start()
    {
        // ��������� ����������
        OutSaveAudioSattings();

        // ��������� ���������
        ChackMusicValue();
        ChackSoundValue();
    }
    private void MusicValue()
    {
        SourceMusic.volume = SliderMusic.value / 100;

        ChackMusicValue();
    }
    private void SoundValue()
    {
        SourceSound.volume = SliderSound.value / 100;

        ChackSoundValue();
    }

    // �������� ������
    private void ChackMusicValue()
    {
        if (SourceMusic.volume > 0)
        {
            ImageMusic.sprite = SpriteMusic[0];// ���
        }
        else if (SourceMusic.volume == 0)
        {
            ImageMusic.sprite = SpriteMusic[1];// ����
        }
    }
    // �������� �����
    private void ChackSoundValue()
    {
        if (SourceSound.volume > 0)
        {
            ImageSound.sprite = SpriteSound[0];// ���
        }
        else if (SourceSound.volume == 0)
        {
            ImageSound.sprite = SpriteSound[1];// ����
        }
    }

    // ���������� ���������
    private void SaveAudioSattings()
    {
        PlayerPrefs.SetFloat("SoundValueSlider", SliderSound.value);
        PlayerPrefs.SetFloat("MusicValueSlider", SliderMusic.value );
    }

    // �������� ���������� 
    private void OutSaveAudioSattings()
    {
        if (PlayerPrefs.HasKey("SoundValueSlider"))
        {
            SliderSound.value = PlayerPrefs.GetFloat("SoundValueSlider");
        }
        else
        {
            SliderSound.value = 50f;
        }

        if (PlayerPrefs.HasKey("MusicValueSlider"))
        {
            SliderMusic.value = PlayerPrefs.GetFloat("MusicValueSlider");
        }
        else
        {
            SliderMusic.value = 30f;
        }
        AcceptSettings();
    }

    // ���������� ��������
    public void AcceptSettings()
    {
        MusicValue();
        SoundValue();
        SaveAudioSattings();
    }
}
