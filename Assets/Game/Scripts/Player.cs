using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private CharacterController _controller;
    [SerializeField]
    private float _speed = 3f;
    private float _gravity = 9.81f;
    [SerializeField]
    private GameObject _muzzleFire;
    [SerializeField]
    private GameObject _hitMarkerPrefab;
    [SerializeField]
    private AudioSource _audioSource;

    void Start() {
        _muzzleFire.SetActive(false);
        _controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        if (Input.GetMouseButton(0)) {
            if (!_audioSource.isPlaying) {
                _audioSource.Play();
            }
            _muzzleFire.SetActive(true);
            Ray rayOrign = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrign, out hitInfo)) {
                Debug.Log("Hit: " + hitInfo.transform.name);
                GameObject hitMarker = Instantiate(_hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(hitMarker, 0.3f);
            }
        }
        else {
            _muzzleFire.SetActive(false);
            _audioSource.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;

        velocity = transform.transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);
    }
}