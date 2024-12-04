using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NoteKey : MonoBehaviour
{
    [SerializeField]
    private string noteName;

    public string Note {
        get { return noteName; }
    }

    private AudioSource mAudioSource;

    private void Awake()
    {
        mAudioSource = GetComponent<AudioSource>();
    }

    public void SetClip(AudioClip aClip)
    {
        mAudioSource.clip = aClip;
    }

    public void Play()
    {
        if (mAudioSource.isPlaying) mAudioSource.Stop();
        mAudioSource.Play();
    }

    public void Stop()
    {
        mAudioSource.Stop();    
    }
}
