using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Undercooked.UI
{
    public class CrateUI : MonoBehaviour
    {
        public TextMeshProUGUI uiText;
        public bool isTextActiveFlag;
        private void Start()
        {
            InitializeUI();
            isTextActive(false);
        }
        private void InitializeUI()
        {
            uiText = GetComponentInChildren<TextMeshProUGUI>();

            uiText.text = "Press Spacebar to Pickup";
        }
        public bool isTextActive(bool isTextActive)
        {
            isTextActive = isTextActiveFlag;
            if (isTextActive)
            {
                uiText.gameObject.SetActive(true);
            }
            else
            {
                uiText.gameObject.SetActive(false);
            }
            //comments
            Debug.Log("Is text active " +isTextActive);
            return isTextActive;
        }
    }
}
