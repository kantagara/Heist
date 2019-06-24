using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _GameAssets.Scripts.Core
{
    public class InteractableControl : MonoBehaviour
    {
        private Camera _camera;
        
        private Coroutine _coroutine;
        
        [SerializeField] private float _timeToWaitForNew = 5f;
        
        private void Awake()
        {
            _camera = Camera.main;
        }
        
        private void Update()
        {
            if(!Input.GetMouseButton(0)) return;
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out var hit)) return;
            var interactable = hit.transform.GetComponent<Interactable>();
            interactable?.Interact();
        }

       
    }
}