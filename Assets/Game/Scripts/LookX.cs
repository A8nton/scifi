using UnityEngine;

public class LookX : MonoBehaviour {

    [SerializeField]
    private float _sensitivity = 2f;

    void Update() {
        float _mouseX = Input.GetAxis("Mouse X");

        Vector3 angles = transform.localEulerAngles;
        angles.y += _mouseX * _sensitivity;
        transform.localEulerAngles = angles;
    }
}
