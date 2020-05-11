using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour{

    [SerializeField]
    private Text _ammoText;

    public void UpdateAmmo(int count, int total) {
        _ammoText.text = string.Format("Ammo: {0} / {1}", count, total);
    }
}
