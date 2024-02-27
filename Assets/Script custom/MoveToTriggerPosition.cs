using UnityEngine;

public class MoveToTriggerPosition : MonoBehaviour
{
    public Transform targetPosition; // Objek target yang akan dijadikan posisi tujuan
    public float moveSpeed = 15f; // Kecepatan pergerakan bola
    public string theobjecttagged = "TheBall";
    public bool moveOnXAxis = false; // Apakah akan bergerak pada sumbu X
    public bool moveOnYAxis = false; // Apakah akan bergerak pada sumbu Y
    public bool moveOnZAxis = false; // Apakah akan bergerak pada sumbu Z

    private bool isMoving = false; // Status pergerakan bola

    // Dipanggil ketika bola memasuki area trigger
    private void OnTriggerEnter(Collider other)
    {
        // Periksa apakah yang masuk trigger adalah bola
        if (other.CompareTag(theobjecttagged))
        {
            // Aktifkan pergerakan bola ke posisi target
            isMoving = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Pergerakan bola ke posisi target jika sedang dalam status pergerakan
        if (isMoving)
        {
            // Tentukan posisi target berdasarkan sumbu yang dipilih
            Vector3 targetPos = transform.position;
            if (moveOnXAxis)
            {
                targetPos.x = targetPosition.position.x;
            }
            if (moveOnYAxis)
            {
                targetPos.y = targetPosition.position.y;
            }
            if (moveOnZAxis)
            {
                targetPos.z = targetPosition.position.z;
            }

            // Menggunakan Lerp untuk pergerakan yang mulus
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

            // Periksa jika bola sudah mendekati posisi target dengan toleransi jarak tertentu
            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                // Hentikan pergerakan
                isMoving = false;
            }
        }
    }
}
