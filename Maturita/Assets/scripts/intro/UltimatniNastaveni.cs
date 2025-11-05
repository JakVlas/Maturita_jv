using UnityEngine;
using UnityEngine.Audio;

public class UltimatniNastaveni : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolume(float hlasitost)
    {
        audioMixer.SetFloat("Master", hlasitost);
    }

    public void SetQuality(int qIndex)
    {
        QualitySettings.SetQualityLevel(qIndex);
    }

    public void FullScr(bool isFC)
    {
        Screen.fullScreen = isFC;
    }
}
