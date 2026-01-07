using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    Rigidbody m_Rigidbody;
    public int damage;
    public GameObject hrac;


    void Start()
    {
        hrac = GameObject.FindGameObjectWithTag("Player");
    }
        
    public void TakeDamage(int amount)
    {
        health -=amount;
        Debug.Log(health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        hrac.GetComponent<Zivoty>().Kills +=1;
        
        if (hrac.GetComponent<Zivoty>().Kills >= 15){hrac.GetComponent<Zivoty>().Vitez();}
        Destroy(gameObject); 
    }

    public void Utok()
    {
        Zivoty zivotys = GameObject.FindWithTag("Player").GetComponent<Zivoty>();
        zivotys.takeDamage(damage);
    }
}
