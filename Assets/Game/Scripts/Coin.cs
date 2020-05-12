using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    [SerializeField]
    private AudioClip _pickupClip;
    [SerializeField]
    private GameObject _popupText;

    public void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {
            _popupText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E)) {
                Player player = GameObject.Find("Player").GetComponent<Player>();

                if (!player.hasCoin) {
                    _popupText.SetActive(false);
                    player.hasCoin = true;
                    AudioSource.PlayClipAtPoint(_pickupClip, transform.position);
                    Destroy(gameObject);
                }
            }
        }
    }

    public void OnTriggerExit(Collider other) {
        _popupText.SetActive(false);
    }
}
