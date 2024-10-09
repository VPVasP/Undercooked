using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Undercooked
{
    public class IngredientUI : MonoBehaviour
    {
        public TextMeshProUGUI uiText;
        public bool isActive = false;
        public bool isControllerPluggedIn = false;
        private Canvas canvas;
        private Transform mainCamTransform;
        public Image controllerInputImage;
        public Sprite[] controllerSprites;
        // Start is called before the first frame update
        void Start()
        {
            uiText = GetComponentInChildren<TextMeshProUGUI>();
            canvas = GetComponentInChildren<Canvas>();
            controllerInputImage = GetComponentInChildren<Image>();
            mainCamTransform = Camera.main.transform;
        }

        public void SetPickUpUI(string msg)
        {
            uiText.text = msg;
        }

        private void Update()
        {
            UIFaceCamera();
            CheckForControllerInput();
        }
        private bool CheckForControllerInput()
        {
            if (Gamepad.current != null)
            {
                isControllerPluggedIn = true;
            }
            if (isControllerPluggedIn)
            {
                isActive = false;
                controllerInputImage.enabled = true;
                uiText.gameObject.SetActive(false);
            }
            else
            {
                isActive = true;
                controllerInputImage.gameObject.SetActive(false);
                uiText.gameObject.SetActive(true);
            }

            return isControllerPluggedIn;
        }
        public void SetControllerImageInput(Sprite imageSprite)
        {
            controllerInputImage.sprite = imageSprite;
        }
        private void UIFaceCamera()
        {
            canvas.transform.LookAt(transform.position + mainCamTransform.rotation * Vector3.forward, mainCamTransform.rotation * Vector3.up);
        }
        public void DisableControllerImage()
        {
            controllerInputImage.gameObject.SetActive(false);
        }
        public void EnableControllerImage()
        {
            controllerInputImage.gameObject.SetActive(true);
        }
    }

}
