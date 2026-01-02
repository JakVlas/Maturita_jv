using UnityEngine;

public class ExplodingEnemy : MonoBehaviour
{
    public float explosionRadius = 5f;
    public float explosionDamage = 50f;
    public float triggerDistance = 2f;
    public LayerMask playerLayer;
    public GameObject explosionEffect;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= triggerDistance)
        {
            Explode();
        }
    }

    void Explode()
    {
        // particle
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // detekce
        
        Collider[] hitColliders = Physics.OverlapSphere(
            transform.position,
            explosionRadius,
            playerLayer
        );

        foreach (Collider hit in hitColliders)
        {
            Zivoty zivotys = hit.GetComponent<Zivoty>();
            if (zivotys != null)
            {
                float distance = Vector3.Distance(transform.position, hit.transform.position);
                float damage = explosionDamage * (1 - distance / explosionRadius);
                damage = Mathf.Max(damage, 0);

                zivotys.takeDamage(damage);
            }
        }

        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}

