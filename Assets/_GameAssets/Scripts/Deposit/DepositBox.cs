
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Heist.Deposit
{
    public class DepositBox :  Interactable
    {
        [SerializeField] private GameObject[] _instatiationLocations;
        [SerializeField] private GameObject[] _objectsToInstantiate;
        [SerializeField] private Rigidbody _lid;
        [SerializeField] private Vector3 _force;

        private Tween _tween;
        private bool _tweenPlayed;

        private void Awake()
        {
            foreach (var location in _instatiationLocations)
            {
                var index = Random.Range(0, _objectsToInstantiate.Length);
                Instantiate(_objectsToInstantiate[index], 
                    location.transform.position, Quaternion.identity, location.transform);
            }
        }

        public override void Interact()
        {
            if(_tween != null && _tween.IsPlaying()) return;
            if (_tween == null && !_tweenPlayed)
            {
                _tween = transform.DOMoveZ(1, .5f).OnComplete(() =>
                {
                    _tweenPlayed = true;
                    _tween = null;
                });
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

        public override void InteractionStopped()
        {
        }
    }
}