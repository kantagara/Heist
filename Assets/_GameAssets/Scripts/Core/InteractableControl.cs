using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _GameAssets.Scripts.Core
{
    public class InteractableControl : MonoBehaviour
    {
        private Camera _camera;
        private bool _newInteractable;
        
        private GameObject _objectInteractingWith;
        private IInteractable _interactable;
        private Coroutine _coroutine;
        
        [SerializeField] private float _timeToWaitForNew = 5f;
        
        private void Awake()
        {
            _camera = Camera.main;
            _newInteractable = true;
        }


        private void Update()
        {
            if(!Input.GetMouseButton(0)) return;

            if (_newInteractable)
            {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    print(hit.transform.gameObject.name);
                    var p = hit.transform.GetComponent<IInteractable>();
                    if (p == null) return;
                    _interactable = p;
                    _objectInteractingWith = hit.transform.gameObject;
                    _newInteractable = false;
                }
            }
            else if (_coroutine == null && (!_objectInteractingWith || !_objectInteractingWith.activeInHierarchy))
            {
                _coroutine = StartCoroutine(GetNewInteractable());
            }
            else 
                _interactable?.Interact();
        }

        private IEnumerator GetNewInteractable()
        {
            yield return new WaitForSeconds(_timeToWaitForNew);
            _interactable = null;
            _objectInteractingWith = null;
            _newInteractable = true;
            _coroutine = null;
        }
    }
}