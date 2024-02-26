using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier = 3f;

    // tambahkan audio manager untuk mengakses fungsi pada audio managernya
    public AudioManager audioManager;

    // untuk mengatur warna bumper
    public Color color;



    // komponen renderer pada object yang akan diubah
    private Renderer renderer;

    // Variabel untuk menyimpan warna awal bumper
    private Color initialColor;

    private Animator animator;


    public VFXManager vfxManager;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();

        animator = GetComponent<Animator>();

        initialColor = renderer.material.color;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            // ambil rigidbody nya lalu kali kecepatannya sebanyak multiplier agar bisa memantul lebih cepat
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;


            UnityEngine.Debug.Log(gameObject.name + " collided with bola");
            // kita jalankan SFX saat tabrakan dengan bola pada posisi tabrakannya
            audioManager.PlaySFX(collision.transform.position);

            //renderer.material.color = color;

            vfxManager.PlayVFX(collision.transform.position);

            animator.SetTrigger("HitBall");


        }
            
    }

   

}
