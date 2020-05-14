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
    [SerializeField]
    private int _currentAmmo;
    private int _maxAmmo = 50;
    [SerializeField]
    private int _totalAmmo;
    private UiManager _uiManager;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private GameObject _weapon;
    public bool hasCoin;
    private bool _canFire;
    private float _timeToFire;
    private float _firePause = 0.1f;

    void Start() {
        _muzzleFire.SetActive(false);
        _controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _currentAmmo = _maxAmmo;
        _totalAmmo = 1000;
        _canFire = true;
        _uiManager = GameObject.Find("Canvas").GetComponent<UiManager>();
        _uiManager.UpdateAmmo(_currentAmmo, 1000);
    }

    void Update() {
        if (Input.GetMouseButton(0) && _currentAmmo > 0) {
            Shoot();
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

        if (Input.GetKeyDown(KeyCode.R) && _totalAmmo > 0 && !_muzzleFire.activeSelf && _weapon.activeSelf) {
            StartCoroutine(ReloadCoroutine());
        }
    }

    void Shoot() {
        if (_canFire && Time.time >= _timeToFire && _weapon.activeSelf) {
            _timeToFire = Time.time + _firePause;
            _currentAmmo--;
            if (!_audioSource.isPlaying) {
                _audioSource.Play();
            }
            _muzzleFire.SetActive(true);
            Ray rayOrign = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;
            _uiManager.UpdateAmmo(_currentAmmo, _totalAmmo);

            if (Physics.Raycast(rayOrign, out hitInfo)) {
                Debug.Log("Hit: " + hitInfo.transform.name);
                GameObject hitMarker = Instantiate(_hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(hitMarker, 0.3f);
            }
        }
    }

    IEnumerator ReloadCoroutine() {
        _canFire = false;
        _animator.Play("Reload_anim");
        int neededAmmo = _maxAmmo - _currentAmmo;

        _currentAmmo = _currentAmmo + Mathf.Min(neededAmmo, _totalAmmo);
        _totalAmmo = Mathf.Max(_totalAmmo - neededAmmo, 0);

        yield return new WaitForSeconds(3);
        _uiManager.UpdateAmmo(_currentAmmo, _totalAmmo);
        _canFire = true;
    }
}