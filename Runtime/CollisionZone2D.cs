using System;
using UnityEngine;

namespace Rehcub.Utilities.Physics
{
    [RequireComponent(typeof(Collider2D))]
    public class CollisionZone2D : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;
        [SerializeField] private LayerMask _mask;

        public event Action<Collision2D> OnEnter;
        public event Action<Collision2D> OnStay;
        public event Action<Collision2D> OnExit;

        private void OnValidate()
        {
            _collider = GetComponent<Collider2D>();
            _collider.isTrigger = false;
            _collider.callbackLayers = _mask;
        }

        private void OnCollisionEnter2D(Collision2D collision) => OnEnter?.Invoke(collision);
        private void OnCollisionStay2D(Collision2D collision) => OnStay?.Invoke(collision);
        private void OnCollisionExit2D(Collision2D collision) => OnExit?.Invoke(collision);
    }
}