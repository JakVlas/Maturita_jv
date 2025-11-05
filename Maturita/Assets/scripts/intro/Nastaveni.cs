using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class Nastaveni : MonoBehaviour
{
    public Slider qualitySlider;
    public Slider volumeSlider;
    public AudioMixer mixer;

    private void Start()
    {
        ObnovitNastaveni();
    }

    public void ObnovitNastaveni()
    {
        qualitySlider.value = Nastavenost.Quality;
        volumeSlider.value = Nastavenost.Volume;

        Nastavit();

    }

    public void Nastavit()
    {
        Nastavenost.Quality = (int)qualitySlider.value;
        Nastavenost.Volume = volumeSlider.value;

        QualitySettings.SetQualityLevel(Nastavenost.Quality);
        mixer.SetFloat("Master", Mathf.Log10(Nastavenost.Volume)*20);
    }
}
