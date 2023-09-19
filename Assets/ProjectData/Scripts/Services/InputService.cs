using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Zenject;

namespace Adhik.Services 
{
    public class InputService : MonoBehaviour
    {
        private PlayerAction _playerActionInputs;

        public event Action<Vector2> MoveEvent;
        public event Action JumpEvent;
        public event Action FireEvent;
        public event Action ReloadEvent;
        public event Action WeaponSwitchEvent;

        private Vector2 _moveDirection;

        [Inject]
        public void Construct() 
        {
            _playerActionInputs = new PlayerAction();
            _playerActionInputs.Player.Jump.performed += OnJump;
            _playerActionInputs.Player.Fire.performed += OnFire;
            _playerActionInputs.Player.Reload.performed += OnReload;
            _playerActionInputs.Player.SwitchWeapon.performed += OnWeaponSwitch;
        }

        private void OnWeaponSwitch(InputAction.CallbackContext obj)
        {
            WeaponSwitchEvent?.Invoke();
        }

        private void OnReload(InputAction.CallbackContext obj)
        {
            ReloadEvent?.Invoke();
        }

        private void OnFire(InputAction.CallbackContext obj)
        {
            FireEvent?.Invoke();
        }

        private void OnJump(InputAction.CallbackContext obj)
        {
            JumpEvent?.Invoke();
        }

        // Update is called once per frame
        void Update()
        {
            _moveDirection = _playerActionInputs.Player.Move.ReadValue<Vector2>();
            MoveEvent?.Invoke(_moveDirection);
        }

        private void OnDestroy()
        {
            _playerActionInputs.Player.Jump.performed -= OnJump;
            _playerActionInputs.Player.Fire.performed -= OnFire;
            _playerActionInputs.Player.Reload.performed -= OnReload;
            _playerActionInputs.Player.SwitchWeapon.performed -= OnWeaponSwitch;
        }
    }
}


