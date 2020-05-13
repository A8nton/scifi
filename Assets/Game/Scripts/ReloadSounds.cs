using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadSounds : MonoBehaviour {
    [SerializeField]
    private AudioClip _ammoOutSound;
    [SerializeField]
    private AudioClip _ammoInSound;
    [SerializeField]
    private AudioClip _boltBackSound;

    void AmmoOut() {
        AudioSource.PlayClipAtPoint(_ammoOutSound, transform.position);
    }
    void AmmoIn() {
        AudioSource.PlayClipAtPoint(_ammoInSound, transform.position);
    }
    void BoldBack() {
        AudioSource.PlayClipAtPoint(_boltBackSound, transform.position);
    }
}
