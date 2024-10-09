using System.Collections.Generic;
using JetBrains.Annotations;
using Undercooked.Appliances;
using Undercooked.Model;
using UnityEngine;

namespace Undercooked.Player
{
    public class InteractableController : MonoBehaviour
    {
        [SerializeField] private Transform playerPivot;
        private readonly HashSet<Interactable> _interactables  = new HashSet<Interactable>();

        private void Awake()
        {
            if (playerPivot == null)
            {
                playerPivot = transform;
            }
        }

        /// <summary>
        /// Get the current highlighted interactable. Null if there is none in range.
        /// </summary>
        [CanBeNull]
        public Interactable CurrentInteractable { get; private set; }

        private void OnTriggerEnter(Collider other)
        {
            Interactable interactable = other.gameObject.GetComponent<Interactable>();
            if (!interactable) return;
            
            if (_interactables.Contains(interactable))
            {
                Debug.LogWarning($"[InteractableController] TriggerEnter on a preexisting collider {other.gameObject.name}");
                return;
            }
            _interactables.Add(interactable);

            if (interactable.GetComponent<CrateUI>() != null)
            {
                interactable.GetComponent<CrateUI>().isActive = true;
            }            else
            {
                Debug.Log("No need to do anything since component is not attrached");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Interactable interactable = other.GetComponent<Interactable>();
            if (interactable)
            {
                _interactables.Remove(interactable);
            }
            if (interactable.GetComponent<CrateUI>() != null)
            {
                interactable.GetComponent<CrateUI>().isActive = false;
                interactable.GetComponent<CrateUI>().DisableControllerImage();
            }
            else
            {
                Debug.Log("No need to do anything since component is not attrached");
            }
        }
        
        public void Remove(Interactable interactable)
        {
            _interactables.Remove(interactable);
        }

        private void FixedUpdate()
        {
            Interactable closest = TryGetClosestInteractable();

            // nothing has changed
            if (closest == CurrentInteractable) { return; }
            
            // something has changed (maybe null)
            CurrentInteractable?.ToggleHighlightOff();
            CurrentInteractable = closest;

            // togglesOn only when there is a interactable near
            closest?.ToggleHighlightOn();

            Debug.Log("closest stuff");
        }
        
        /// <summary>
        /// Get the closest interactables from the ones in range. Null if there none in range. 
        /// </summary>
        private Interactable TryGetClosestInteractable()
        {
            var minDistance = float.MaxValue;
            Interactable closest = null;
            foreach (var interactable in _interactables)
            {
                var distance = Vector3.Distance(playerPivot.position, interactable.gameObject.transform.position);
                if (distance > minDistance) continue;
                minDistance = distance;
                closest = interactable;
            }
            return closest;
        }
    }
}
