using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {

    [SerializeField]
    private GameObject _destroyedCrate;

    public void DestroyCreate() {
        Instantiate(_destroyedCrate, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
