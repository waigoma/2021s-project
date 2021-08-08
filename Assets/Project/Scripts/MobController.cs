using System;
using UnityEngine;

namespace Project
{
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class MobController : MonoBehaviour
    {
        private Animator _animator;
        private CapsuleCollider _capsuleCollider;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _animator = GetComponent<Animator>();

            _capsuleCollider = GetComponent<CapsuleCollider>();
            _rigidbody = GetComponent<Rigidbody>();
            
        }

        void OnTriggerEnter(Collider other)
        {
            if (_animator.GetBool("Hit")) return;
            if (other.CompareTag("Weapon"))
            {
                _animator.SetBool("Hit", true);
            }
        }

        void HitEnd()
        {
            _animator.SetBool("Hit", false);
        }
    }
}