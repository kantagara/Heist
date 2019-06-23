using System;
using DG.Tweening;
using UnityEngine;

namespace Heist.Deposit
{
    public class DepositBox : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject[] _instatiationLocations;
        [SerializeField] private GameObject[] _objectsToInstantiate;
        [SerializeField] private Rigidbody _lid;
        [SerializeField] private Vector3 _force;

        private Tween _tween;

        public void Interact()
        {

            if(_tween != null && _tween.IsPlaying()) return;
            if (transform.position.z == 0 && _tween == null)
            {
                _tween = transform.DOMoveZ(1, .5f).OnComplete(() => _tween = null);
                return;
            }

            if (_lid.gameObject.activeInHierarchy)
            {
                _lid.isKinematic = false;
                _lid.useGravity = true;
                _lid.AddForce(_force);
                _lid.AddTorque(_force);
                Invoke("RemoveLid", .7f);
            }
        }

        void RemoveLid()
        {
            _lid.gameObject.SetActive(false);
        }

        public void InteractionStopped()
        {
        }
    }
}