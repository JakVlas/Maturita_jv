using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lupara : MonoBehaviour
{
    public Transform Spawn;
    public float dist = 25f;

    public GameObject muzzle;
    public GameObject impact;

    public Camera cam;

    public int damage;
    public GameObject canfire;
    private Player player_script;

    public AudioSource audio;





    private void Start()
    {
        player_script = canfire.GetComponent<Player>();
        // audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !player_script.Pauznuto)
        {
            Shoot();
        }
    }
    
    // strelba
    private void Shoot()
    {

        // Audio
        audio.Play();


        RaycastHit hit;
        RaycastHit hit1;
        RaycastHit hit2;
        RaycastHit hit3;

        GameObject muzzleInstance=Instantiate(muzzle, Spawn.position, Spawn.localRotation);
        muzzleInstance.transform.parent = Spawn;

        // rovna kulka
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, dist))
        {
            Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            enemy?.TakeDamage(damage);
        }

        if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(-.2f, 0f, 0f), out hit1, dist))
        {
            Instantiate(impact, hit1.point, Quaternion.LookRotation(hit1.normal));
                
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            enemy?.TakeDamage(damage);
        }

        // nahoru

        if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(0f, .1f, 0f), out hit2, dist))
        {
            Instantiate(impact, hit2.point, Quaternion.LookRotation(hit2.normal));

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            enemy?.TakeDamage(damage);
        }
        
        // dolu
        if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(0f, -.1f, 0f), out hit3, dist))
        {
            Instantiate(impact, hit3.point, Quaternion.LookRotation(hit3.normal));

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            enemy?.TakeDamage(damage);
        }
        
        
    }
}
