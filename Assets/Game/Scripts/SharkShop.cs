using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour {

    [SerializeField]
    private GameObject _weapon;
    [SerializeField]
    private GameObject _inventoryCoin;
    [SerializeField]
    private GameObject _buyText;

    public void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {
            _buyText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E)) {
                GetComponent<AudioSource>().Play();
                Player player = GameObject.Find("Player").GetComponent<Player>();

                if (player.hasCoin) {
                    _weapon.SetActive(true);
                    player.hasCoin = false;
                    _inventoryCoin.SetActive(false);
                }
            }
        }
    }

    public void OnTriggerExit(Collider other) {
        _buyText.SetActive(false);
    }
}