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
    [SerializeField, Header("Музыка: ")] private AudioSource SourceMusic;
    [SerializeField, Header("Звук: ")] private AudioSource SourceSound;

    [SerializeField, Header("Спрайт вкл/выкл музыка: ")] private Sprite[] SpriteMusic;
    [SerializeField, Header("Спрайт вкл/выкл звук: ")] private Sprite[] SpriteSound;

    [SerializeField, Header("Картинка музыка: ")] private Image ImageMusic;
    [SerializeField, Header("Картинка звук: ")] private Image ImageSound;

    public void Start()
    {
        // Выгружаем сохранения
        OutSaveAudioSattings();
        // Проверяем параметры
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

    // Проверка музыки
    private void ChackMusicValue()
    {
        if (SourceMusic.volume > 0)
        {
            ImageMusic.sprite = SpriteMusic[0];// вкл
        }
        else if (SourceMusic.volume == 0)
        {
            ImageMusic.sprite = SpriteMusic[1];// выкл
        }
    }
    // Проверка звука
    private void ChackSoundValue()
    {
        if (SourceSound.volume > 0)
        {
            ImageSound.sprite = SpriteSound[0];// вкл
        }
        else if (SourceSound.volume == 0)
        {
            ImageSound.sprite = SpriteSound[1];// выкл
        }
    }

    // Сохранение настройки звука
    private void SaveSoundSattings(Slider SliderSound)
    {
        PlayerPrefs.SetFloat("SoundValueSlider", SliderSound.value);
    }

    // Сохранение настройки музыки
    private void SaveMusickSattings(Slider SliderMusic)
    {
        PlayerPrefs.SetFloat("MusicValueSlider", SliderMusic.value);
    }
    // Выгрузка сохранения 
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

    // Само взаимодействие с кнопкой
    public void _SliderMusick(Slider sliderMusick)
    {
        Debug.Log("Музыка " + sliderMusick.value);
        MusicValue(sliderMusick);
        SaveMusickSattings(sliderMusick);
    }
    public void _SliderSound(Slider sliderSound)
    {
        Debug.Log("Звук " + sliderSound.value);
        SoundValue(sliderSound);
        SaveSoundSattings(sliderSound);
    }
}
