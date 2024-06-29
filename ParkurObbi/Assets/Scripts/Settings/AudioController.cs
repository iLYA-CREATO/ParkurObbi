using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField, Header(": ")] Slider sliderSound;
    [SerializeField, Header(": ")] Slider sliderMusick;
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
    private void MusicValue(Slider SliderMusic)
    {
        sliderMusick.value = SliderMusic.value;
        SourceMusic.volume = sliderMusick.value / 100;

        ChackMusicValue();
    }
    private void SoundValue(Slider SliderSound)
    {
        sliderSound.value = SliderSound.value;
        SourceSound.volume = sliderSound.value / 100;

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

    // ���������� ��������� �����
    private void SaveSoundSattings(Slider SliderSound)
    {
        PlayerPrefs.SetFloat("SoundValueSlider", SliderSound.value);
    }

    // ���������� ��������� ������
    private void SaveMusickSattings(Slider SliderMusic)
    {
        PlayerPrefs.SetFloat("MusicValueSlider", SliderMusic.value);
    }
    // �������� ���������� 
    private void OutSaveAudioSattings()
    {
        if (PlayerPrefs.HasKey("SoundValueSlider"))
        {
            sliderSound.value = PlayerPrefs.GetFloat("SoundValueSlider");
        }
        else
        {
            sliderSound.value = 50f;
        }

        if (PlayerPrefs.HasKey("MusicValueSlider"))
        {
            sliderMusick.value = PlayerPrefs.GetFloat("MusicValueSlider");
        }
        else
        {
            sliderMusick.value = 30f;
        }
    }

    // ���� �������������� � �������
    public void _SliderMusick(Slider sliderMusick)
    {
        Debug.Log("������ " + sliderMusick.value);
        MusicValue(sliderMusick);
        SaveMusickSattings(sliderMusick);
    }
    public void _SliderSound(Slider sliderSound)
    {
        Debug.Log("���� " + sliderSound.value);
        SoundValue(sliderSound);
        SaveSoundSattings(sliderSound);
    }
}
