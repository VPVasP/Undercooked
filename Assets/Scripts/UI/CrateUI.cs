using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Undercooked.Appliances
{
    public class CrateUI : MonoBehaviour
    {
        public bool isTextActiveBool;
        public TextMeshProUGUI uiText;
        private void Start()
        {
            InitializeUI();
        }
        private void InitializeUI()
        {
            uiText = GetComponentInChildren<TextMeshProUGUI>();

            SetUITextMessage("Press Space to Pickup");
        }
        private void Update()
        {
            isTextActive();
        }
        public void SetUITextMessage(string text)
        {
            uiText.text = text;
        }
        public bool isTextActive()
        {
            if (isTextActiveBool)
            {
                uiText.gameObject.SetActive(true);
            }
            else
            {
                uiText.gameObject.SetActive(false);
            }
            return isTextActiveBool;
        }
    }
}
