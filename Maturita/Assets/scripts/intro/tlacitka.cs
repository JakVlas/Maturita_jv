using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class tlacitka: MonoBehaviour
{
    public string scena;

    public void Zmena_sceny(string scena)
    {
        SceneManager.LoadScene(scena);
    }

    public void Konec()
    {
        Application.Quit();
    }

}