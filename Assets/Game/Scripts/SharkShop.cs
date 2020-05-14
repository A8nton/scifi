using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour {

    [SerializeField]
    private GameObject _weapon;
    [SerializeField]
    private GameObject _inventoryCoin;

    public void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)) {
            Player player = GameObject.Find("Player").GetComponent<Player>();
            if (player.hasCoin) {
                _weapon.SetActive(true);
                player.hasCoin = false;
                _inventoryCoin.SetActive(false);
            }
        }
    }
}