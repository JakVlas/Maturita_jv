using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    Rigidbody m_Rigidbody;
    public int damage;
        
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
        Destroy(gameObject); 
    }

    public void Utok()
    {
        Zivoty zivotys = GameObject.FindWithTag("Player").GetComponent<Zivoty>();
        zivotys.takeDamage(damage);
    }
}
