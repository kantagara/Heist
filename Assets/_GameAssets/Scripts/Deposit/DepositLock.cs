using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Heist.Deposit
{
    
    public class DepositLock : Interactable
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

        public override void Interact()
        {
            //TODO: Enable UI to see the progress how much it's left
            TryUnlocking();
        }

        public override void InteractionStopped()
        {
            //TODO: Disable UI progress
        }
    }
}

