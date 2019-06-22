using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Heist.Deposit
{
    
    public class DepositLock : MonoBehaviour
    {
        [SerializeField] private float _timeToUnlock;
        [SerializeField] private GameObject _particles;
        private ParticleSystem _particlesInstance;
        private float _timeUnlocking;

        private void Awake()
        {
            if (!_particles) return;
            _particlesInstance = Instantiate(_particles).GetComponent<ParticleSystem>();
            _particlesInstance.Stop();
        }

        private void OnMouseOver()
        {
            if (Input.GetMouseButton(0))
                TryUnlocking();
        }

        private void TryUnlocking()
        {
            _timeUnlocking += Time.deltaTime;
            if (_particles && _timeUnlocking % (_timeToUnlock / 10) < .1f && !_particlesInstance.isPlaying)
                _particlesInstance.Play();
            if (_timeUnlocking >= _timeToUnlock)
            {
                LockUnlocked();
            }
        }

        private void LockUnlocked()
        {
            gameObject.SetActive(false);
        }
    }
}

