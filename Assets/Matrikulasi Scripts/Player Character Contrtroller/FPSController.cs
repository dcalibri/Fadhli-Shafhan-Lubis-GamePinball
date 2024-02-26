using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float speed = 5.0f;
    public float runSpeed = 10.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    public Camera playerCamera;

    public float lookSpeed = 2.0f;
    public float XRotationLimit = 45.0f;

    private CharacterController controller;
    private float rotationX = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Mendapatkan arah maju dan ke kanan dari transformasi karakter
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        // Mendapatkan input pergerakan dari input horizontal dan vertikal
        float curSpeedX = speed * Input.GetAxis("Vertical");
        float curSpeedY = speed * Input.GetAxis("Horizontal");

        // Menghitung pergerakan berdasarkan input dan kecepatan
        Vector3 movement = (forward * curSpeedX) + (right * curSpeedY);

        // Memeriksa jika karakter sedang di udara
        if (!controller.isGrounded)
        {
            // Mengaplikasikan gaya gravitasi ke arah bawah
            movement.y -= gravity * Time.deltaTime;
        }
        else
        {
            // Reset kecepatan vertikal jika karakter menyentuh tanah
            movement.y = 0f;

            // Memeriksa jika pemain menekan tombol loncat
            if (Input.GetButtonDown("Jump"))
            {
                // Memberikan gaya loncat ke atas
                movement.y = jumpSpeed;
            }
        }

        // Menggerakkan karakter menggunakan CharacterController
        controller.Move(movement * Time.deltaTime);

        // Mengatur rotasi kamera vertikal (look up and down)
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -XRotationLimit, XRotationLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        // Mengatur rotasi karakter horizontal (look left and right)
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }

}
