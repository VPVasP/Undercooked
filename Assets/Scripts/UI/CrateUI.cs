using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Undercooked.Appliances
{
    public class CrateUI : MonoBehaviour
    {
        public bool isActive;
        public bool isControllerPluggedIn = false;
        public TextMeshProUGUI uiText;
        private Transform mainCamTransform;
        public Image controllerInputImage;
        public Sprite[] controllerSprites;
        private void Start()
        {
            InitializeUI();
        }
        private void InitializeUI()
        {
            uiText = GetComponentInChildren<TextMeshProUGUI>();
            controllerInputImage = GetComponentInChildren<Image>();
            SetUITextMessage("Press Space to Pickup");
            //set the icon to be a
            SetControllerImageInput(controllerSprites[0]);
        }
        private void Update()
        {
            CheckForControllerInput();
        }
        public void SetUITextMessage(string text)
        {
            uiText.text = text;
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