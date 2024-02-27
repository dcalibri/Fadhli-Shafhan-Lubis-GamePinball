using UnityEngine;
using System.Collections;

public class SwitchController : MonoBehaviour
{
    public enum SwitchState
    {
        Off,
        On,
        Blink
    }

    public Collider bola;
    public Material offMaterial;
    public Material onMaterial;

    public SwitchState state;
    private Renderer renderer;
    public ScoreManager scoreManager;

    public AudioSource theAudioSourceOn;
    public AudioSource theAudioSourceOff;
    public VFXManager vfxManager;

    public float score = 20f;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        Set(false);
        StartCoroutine(BlinkTimerStart(5));
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            Toggle(other.transform.position);
        }
    }

    public void Toggle(Vector3 spawnPosition)
    {
        if (state == SwitchState.On)
        {
            Set(false);
            theAudioSourceOff.Play();
        }
        else
        {
            Set(true);
            theAudioSourceOn.Play();
            vfxManager.PlayVFX(spawnPosition); // Spawn particle effect at the switch position
            scoreManager.AddScore(score);
        }
    }

    public void ForceOff()
    {
        Set(false);
        theAudioSourceOff.Play();
    }

    private void Set(bool active)
    {
        if (active)
        {
            state = SwitchState.On;
            renderer.material = onMaterial;
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.Off;
            renderer.material = offMaterial;
            StartCoroutine(BlinkTimerStart(5));
        }
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }

    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;

        for (int i = 0; i < times; i++)
        {
            renderer.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            renderer.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        state = SwitchState.Off;

        StartCoroutine(BlinkTimerStart(5));
    }
}
