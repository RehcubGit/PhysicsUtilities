using System;
using UnityEngine;

namespace Rehcub.Utilities.Physics
{
    [RequireComponent(typeof(Collider))]
    public class CollisionZone : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private LayerMask _mask;

        public event Action<Collision> OnEnter;
        public event Action<Collision> OnStay;
        public event Action<Collision> OnExit;

        private void OnValidate()
        {
            _collider = GetComponent<Collider>();
            _collider.isTrigger = false;
            _collider.includeLayers = _mask;
        }

        private void OnCollisionEnter(Collision collision) => OnEnter?.Invoke(collision);
        private void OnCollisionStay(Collision collision) => OnStay?.Invoke(collision);
        private void OnCollisionExit(Collision collision) => OnExit?.Invoke(collision);
    }
}