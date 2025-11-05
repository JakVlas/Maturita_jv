using UnityEngine;

public class Setup : MonoBehaviour
{
    public GameObject Nastaveni;
    public GameObject Menu;
    void Start()
    {
        Nastaveni.SetActive(false);
        Menu.SetActive(true);
    }

}
