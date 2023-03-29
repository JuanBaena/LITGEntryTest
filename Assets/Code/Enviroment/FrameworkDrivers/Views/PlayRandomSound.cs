 using UnityEngine;
 
 public class PlayRandomSound : MonoBehaviour, IPlayRandomSound
{
    [SerializeField]
    private AudioSource randomSound;
    [SerializeField]
    private AudioClip[] audioSources;
    [SerializeField]
    private int clipDelay;

    private void Reset()
    {
        clipDelay = 5;
    }
    private void Start ()
    {
        StartAudio ();
    }

    public void StartAudio()
    {
        Invoke("RandomSoundness", clipDelay);
    }

    private void RandomSoundness()
    {
        randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
        randomSound.Play();
        StartAudio();
    }
}