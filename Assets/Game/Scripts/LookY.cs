using UnityEngine;

public class LookY : MonoBehaviour {

    [SerializeField]
    private float _sensitivity = 2f;

    void Update() {
        float _mouseY = Input.GetAxis("Mouse Y") * -1;

        Vector3 angles = transform.localEulerAngles;
        angles.x += _mouseY * _sensitivity;
        transform.localEulerAngles = angles;
    }
}
