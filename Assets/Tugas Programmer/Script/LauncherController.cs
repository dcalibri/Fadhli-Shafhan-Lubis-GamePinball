using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public Collider bola; // referensi ke bola
    public KeyCode input; // tombol input untuk aktivasi launch

    // untuk set berapa lama waktu yang harus dicapai hingga maksimal force
    public float maxTimeHold;
    // untuk set berapa besar maksimal force yang bisa didapat (ini menggantikan force)
    public float maxForce = 1000f;

    // state pada launcher
    public bool isHold;
    public bool adaBola;

    // Warna pada saat awal
    private Color startColor;
    private Renderer renderer; // Renderer component untuk mengubah warna

    void Start()
    {
        // di set false state nya saat baru mulai
        isHold = false;
        adaBola = false;
        renderer = bola.GetComponent<Renderer>(); // Assign the Renderer component
        startColor = bola.GetComponent<Renderer>().material.color; // Simpan warna awal bola
        UnityEngine.Debug.Log("ready to press : " + input);
    }



    private void Update()
    {
        if (adaBola)
        {
            
            ReadInput(bola);
            UnityEngine.Debug.Log("Bola Detected");
        }
    }
    // hanya dapat membaca input saat bersentuhan dengan bola saja
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == bola)
        {
            adaBola = true;
        }
    }

    // baca input
    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input))
        {
            UnityEngine.Debug.Log(input);
            StartCoroutine(StartHold(collider));
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;

        float force = 0.0f;
        float timeHold = 0.0f;

        // Waktu awal hold
        float startTime = Time.time;

        while (Input.GetKey(input) && timeHold < maxTimeHold)
        {
            force = Mathf.Lerp(0, maxForce, timeHold / maxTimeHold);

            // Hitung waktu hold saat ini
            timeHold = Time.time - startTime;

            // Hitung persentase warna merah berdasarkan waktu hold
            float redPercentage = Mathf.Min(1.0f, timeHold / maxTimeHold); // Batasi nilai menjadi maksimal 1.0f
            // Buat warna baru dengan nilai merah yang berubah seiring waktu hold
            Color newColor = new Color(startColor.r + redPercentage, startColor.g, startColor.b);
            // Terapkan warna baru ke launcher
            renderer.material.color = newColor;

            UnityEngine.Debug.Log("Input sedang ditekan (hold): " + input);

            yield return new WaitForEndOfFrame();
        }

        UnityEngine.Debug.Log("Input tidak sedang ditekan (hold): " + input);

        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);

        // Reset warna launcher ke warna awal setelah selesai menjalankan aksi
        renderer.material.color = startColor;

        isHold = false;
        adaBola = false; // Reset adaBola ketika selesai menjalankan aksi
    }
}