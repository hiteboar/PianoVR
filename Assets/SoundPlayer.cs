using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] pianoNoteClips;
    [SerializeField]
    private NoteKey[] noteKeys;

    private Dictionary<string, NoteKey> mKeys;

    private void Awake()
    {
        mKeys = new Dictionary<string, NoteKey>();
        
        foreach(NoteKey key in noteKeys) {
            mKeys.Add(key.Note, key);
        }
        
        for (int i = 0; i < pianoNoteClips.Length; i++) {
            string lNoteName = pianoNoteClips[i].name;
            if (mKeys.ContainsKey(lNoteName)) {
                string lKeyName = pianoNoteClips[i].name;
                mKeys[lKeyName].SetClip(pianoNoteClips[i]);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        NoteKey noteKey = other.GetComponent<NoteKey>();
        if (noteKey == null) return;
        noteKey.Play();
    }
}
