using UnityEngine;

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

        }
    }
    
    // strelba
    private void Shoot()
    {
        RaycastHit hit;
        RaycastHit hit1;
        RaycastHit hit2;
        RaycastHit hit3;

        GameObject muzzleInstance = Instatiate(muzzle, Spawn.position, Spawn.localRotation);
        muzzleInstance.transform.parent = Spawn;

        // rovna kulka
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance))
        {
            Instatiate(impact, hit.point, Quaternion.LookRotation(hit.normal));

        }

        if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(-.2f, 0f, 0f), out hit1, distance))
        {
            Instatiate(impact, hit1.point, Quaternion.LookRotation(hit1.normal));

        }

        // nahoru

        if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(0f, .1f, 0f), out hi2, distance))
        {
            Instatiate(impact, hit2.point, Quaternion.LookRotation(hit2.normal));

        }
        
        // dolu
        if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(0f, -.1f, 0f), out hi3, distance))
        {
            Instatiate(impact, hit3.point, Quaternion.LookRotation(hit3.normal));

        }
        
        
    }
}
