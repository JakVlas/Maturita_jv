using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class zivoty : MonoBehaviour
{
    public Slider healthbar;
    public TMP_Text health;


    public void Zmena_sceny(string scena){
        SceneManager.LoadScene(scena);
    }
    // Update is called once per frame
    void Update()
    {
        //health.SetText(player.zivoty_hrace.ToString());
        //healthbar.value = player.zivoty_hrace;
    }
}