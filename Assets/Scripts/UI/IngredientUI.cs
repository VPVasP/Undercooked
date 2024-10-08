using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Undercooked
{
    public class IngredientUI : MonoBehaviour
    {
        public TextMeshProUGUI uiText;
        public bool isActive = false;
        private Canvas canvas;
        private Transform mainCamTransform;
        // Start is called before the first frame update
        void Start()
        {
            uiText = GetComponentInChildren<TextMeshProUGUI>();
            canvas = GetComponentInChildren<Canvas>();
            mainCamTransform = Camera.main.transform;
        }

        public void SetPickUpUI(string msg)
        {
            uiText.text = msg;
        }
        private void Update()
        {
            UIActivity();
            UIFaceCamera();
        }
        private void UIFaceCamera() {

            canvas.transform.LookAt(transform.position + mainCamTransform.rotation * Vector3.forward, mainCamTransform.rotation * Vector3.up);
          
        }
        public bool UIActivity()
        {
            if (isActive)
            {
                uiText.gameObject.SetActive(true);
            }
            else
            {
                uiText.gameObject.SetActive(false);
            }
            return isActive;
        }
    }
}
