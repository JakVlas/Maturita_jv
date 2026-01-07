using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Zivoty : MonoBehaviour
{
//  UI
    public Slider healthbar;
    public TMP_Text health;
    public Slider cholesterol;
    public TMP_Text cholest;
// stats
    public float zivoty_hrace = 100f;
    public int Cholesterol = 0;
    public int Kills;

// sceny
    public string vitezna_scena;
    public string proherni_scena;


    private void Start()
    {
        health.SetText(zivoty_hrace.ToString ("0"));
        cholest.SetText(Cholesterol.ToString());
        cholesterol.value = Cholesterol;
        Kills = 0;
    }
    public void Zmena_sceny(string scena){
        SceneManager.LoadScene(scena);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
    private void OnCollisionEnter(Collision collision)
        {   
            Debug.Log("dotek");

            if (collision.gameObject.tag == "Donut")
            {   if (zivoty_hrace <= 80)
                {
                    zivoty_hrace += 20;
                    Cholesterol += 20;
                    health.SetText(zivoty_hrace.ToString ("0"));
                    healthbar.value = zivoty_hrace;
                    cholest.SetText(Cholesterol.ToString ("0"));
                    cholesterol.value = Cholesterol;
                }
                else
                {
                    zivoty_hrace = 100;
                    Cholesterol += 20;
                    cholest.SetText(Cholesterol.ToString());
                    cholesterol.value = Cholesterol;
                }
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.tag == "Pilulky")
            {
                if (Cholesterol >= 20)
                {
                    Cholesterol -= 20;
                    cholest.SetText(Cholesterol.ToString());
                    cholesterol.value = Cholesterol;
                }
                else
                {
                    Cholesterol = 0;
                    cholest.SetText(Cholesterol.ToString());
                    cholesterol.value = Cholesterol;
                }    

                UnityEngine.Debug.Log("pilule");
                Destroy(collision.gameObject);
            }
        }
    public void takeDamage(float damage)
    {
        zivoty_hrace -= damage;
        health.SetText(zivoty_hrace.ToString ("0"));
        healthbar.value = (int)zivoty_hrace;

        if (zivoty_hrace <=0)
        {
            Debug.Log("die");
            Proher();
        }
    }
    public void Vitez()
    {
        Zmena_sceny(vitezna_scena);
    }
    public void Proher()
    {
        Zmena_sceny(proherni_scena);
    }
}