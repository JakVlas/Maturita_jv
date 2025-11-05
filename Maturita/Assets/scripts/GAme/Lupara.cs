using UnityEngine;using System.Collections; using System.Collections.Generic;

public class Lupara : MonoBehaviour
{
    public Transform Spawn;
    public float dist = 15f;

    public GameObject muzzle;
    public GameObject impact;

    Camera cam;

    void Start()
    {
        cam = Camera.main;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
            Debug.Log("shoot");
        }
    }
    
    // strelba
    private void Shoot()
    {
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

        }

        if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(-.2f, 0f, 0f), out hit1, dist))
        {
            Instantiate(impact, hit1.point, Quaternion.LookRotation(hit1.normal));

        }

        // nahoru

        if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(0f, .1f, 0f), out hit2, dist))
        {
            Instantiate(impact, hit2.point, Quaternion.LookRotation(hit2.normal));

        }
        
        // // dolu
        if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(0f, -.1f, 0f), out hit3, dist))
        {
            Instantiate(impact, hit3.point, Quaternion.LookRotation(hit3.normal));

        }
        
        
    }
}
