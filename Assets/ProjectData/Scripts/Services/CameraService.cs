using System;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace Adhik.Services 
{
    public class CameraService : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _playerCamera;
        [SerializeField] private Camera _mainCamera;

        public event Action<Vector3> LookUpdated;

        [Inject]
        public void Construct()
        {
            
        }

        private void LateUpdate()
        {
            LookUpdated?.Invoke(GetLookDirection());
        }

        public void SetFollowTarget(Transform targetTransform) 
        {
            _playerCamera.Follow = targetTransform;
        }

        public Camera GetPlayerCamera() 
        {
            return _mainCamera;
        }

        public Vector3 GetLookDirection()
        {
            return _mainCamera.transform.forward;
        }
    }
}


