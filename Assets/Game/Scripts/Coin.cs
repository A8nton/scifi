using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    [SerializeField]
    private AudioClip _pickupClip;
    [SerializeField]
    private GameObject _popupText;
    [SerializeField]
    private GameObject _inventoryCoin;

    public void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {
            _popupText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E)) {
                Player player = GameObject.Find("Player").GetComponent<Player>();
                _inventoryCoin.SetActive(true);

                if (!player.hasCoin) {
                    _popupText.SetActive(false);
                    player.hasCoin = true;
                    AudioSource.PlayClipAtPoint(_pickupClip, transform.position);
                    UiManager uiManager = GameObject.Find("Canvas").GetComponent<UiManager>();
                    uiManager.CollectedCoin();
                    Destroy(gameObject);
                }
            }
        }
    }

    public void OnTriggerExit(Collider other) {
        _popupText.SetActive(false);
    }
}
