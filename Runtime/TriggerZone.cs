using System;
using UnityEngine;

namespace Rehcub.Utilities.Physics
{
    [RequireComponent(typeof(Collider))]
    public class TriggerZone : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private LayerMask _mask;

        public event Action<Collider> OnEnter;
        public event Action<Collider> OnStay;
        public event Action<Collider> OnExit;

        private void OnValidate()
        {
            _collider = GetComponent<Collider>();
            _collider.isTrigger = true;
            _collider.includeLayers = _mask;
        }

        private void OnTriggerEnter(Collider other) => OnEnter?.Invoke(other);
        private void OnTriggerStay(Collider other) => OnStay?.Invoke(other);
        private void OnTriggerExit(Collider other) => OnExit?.Invoke(other);
    }
}