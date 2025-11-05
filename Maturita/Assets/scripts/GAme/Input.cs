using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera;

    // movement vars
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    public float defaultHeight = 2f;
    public float crouchHeight = 1f;
    public float crouchSpeed = 3f;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;

    private bool canMove = true;

    // shoot vars
    public int damage;
    public int bps;
    public int range;
    private bool canFire = true;
    public GameObject hitmarker;
    public float distance;
    public int weapon_mode;

    //audioshit
    public AudioSource audio;
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;

    void Start()
    {
        //movement
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // shoot
        HitDisabled();
        canFire = true;
    }

    void Update()
    {

        // Movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if (Input.GetButton("Crouch") && canMove)
        {
            characterController.height = crouchHeight;
            walkSpeed = crouchSpeed;
            runSpeed = crouchSpeed;

        }
        else
        {
            characterController.height = defaultHeight;
            walkSpeed = 6f;
            runSpeed = 12f;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        if (Input.GetButtonDown("Fire3"))
        {
            Change_weapon_mode();
        }
    }

    void Shoot()
    {
        canFire = false;
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                HitActive();
            }
        }
        StartCoroutine(FireRate());


        audio.Play();
    }

    IEnumerator FireRate()
    {
        float TimeForNextShot = 1 / bps;
        yield return new WaitForSeconds(TimeForNextShot);
        HitDisabled();
        canFire = true;
    }

    private void HitActive()
    {
        hitmarker.SetActive(true);
    }

    private void HitDisabled()
    {
        hitmarker.SetActive(false);
    }


    void Change_weapon_mode()
    {
        if (weapon_mode != 2)
        {
            weapon_mode += 1;
        }
        else
        {
            weapon_mode = 0;
        }


        switch (weapon_mode)
        {
            case 0:
                damage = 2;
                range = 100;
                bps = 5;
                audio.clip = sound1;
                break;

            case 1:
                damage = 10;
                range = 5;
                bps = 1;
                audio.clip = sound2;
                break;

            case 2:
                damage = 1;
                range = 10;
                bps = 10;
                audio.clip = sound3;
                break;
        }
    }
}