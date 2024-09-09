using System;
using UnityEngine;

namespace Rehcub.Utilities.Physics
{
    [RequireComponent(typeof(Collider2D))]
    public class TriggerZone2D : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;
        [SerializeField] private LayerMask _mask;

        public event Action<Collider2D> OnEnter;
        public event Action<Collider2D> OnStay;
        public event Action<Collider2D> OnExit;

        private void OnValidate()
        {
            _collider = GetComponent<Collider2D>();
            _collider.isTrigger = true;
            _collider.callbackLayers = _mask;
        }

        private void OnTriggerEnter2D(Collider2D other) => OnEnter?.Invoke(other);
        private void OnTriggerStay2D(Collider2D other) => OnStay?.Invoke(other);
        private void OnTriggerExit2D(Collider2D other) => OnExit?.Invoke(other);
    }
}