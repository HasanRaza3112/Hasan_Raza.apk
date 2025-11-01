using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Audio clips (assign in Inspector)
    public AudioClip chopSound;
    public AudioClip moveSound;
    public AudioClip completeSound;
    
    // Audio source
    private AudioSource audioSource;
    
    void Start()
    {
        // Get or add AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
    
    public void PlayChopSound()
    {
        PlaySound(chopSound);
    }
    
    public void PlayMoveSound()
    {
        PlaySound(moveSound);
    }
    
    public void PlayCompleteSound()
    {
        PlaySound(completeSound);
    }
    
    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}