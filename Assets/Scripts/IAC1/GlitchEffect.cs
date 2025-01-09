using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using URPGlitch.Runtime.DigitalGlitch;

public class GlitchEffect : MonoBehaviour
{
    public AudioSource audioSource;
    public float Initialamount = 0f; // The initial amount
    public float targetAmount = 1f; // The target amount
    public float duration = 0.01f; // The time in seconds over which to reduce the amount
    public Volume volume;

    private float elapsedTime = 0f;
    private DigitalGlitchVolume digitalGlitch;

    bool foundVolume;
   

    void Start() 
    {
        if (volume.profile.TryGet(out digitalGlitch))
        {
            foundVolume = true;
        }
        else
        {
            Debug.LogWarning("DigitalGlitch component not found in the Volume Profile.");
        }
       
        
    }

    void Update()
    {
        
    }

    public void StartTransition(float duration)
    {
        if (foundVolume)
        {
            StopAllCoroutines(); // Stop any ongoing transitions
            StartCoroutine(TransitionCoroutine(duration));
        }
    }

    private IEnumerator TransitionCoroutine(float duration)
    {
        audioSource.Play();
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Increment the elapsed time slowly
            elapsedTime += Time.deltaTime;

            // Interpolate the amount
            float amount = Mathf.Lerp(Initialamount, targetAmount, elapsedTime / duration);

            // Set the amount
            digitalGlitch.intensity.value = amount;


            yield return null; // Wait until the next frame
        }

        // Ensure the target amount is set at the end
        digitalGlitch.intensity.value = targetAmount;

        elapsedTime = 0f;

        // Decrease intensity
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float amount = Mathf.Lerp(targetAmount, Initialamount, elapsedTime / duration);
            digitalGlitch.intensity.value = amount;
            yield return null; // Wait until the next frame
        }

        // Ensure the intensity is back to the initial amount
        digitalGlitch.intensity.value = Initialamount;

    }

   


}
