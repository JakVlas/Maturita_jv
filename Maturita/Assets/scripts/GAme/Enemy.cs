using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 2;
    Rigidbody m_Rigidbody;
    Vector3 m_ZAxis;
    Vector3 velocity; 
    public GameObject cil;
    public Vector3 targetPosition;
    public float smoothTime = 0.5f;
    public float speed;
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
}
