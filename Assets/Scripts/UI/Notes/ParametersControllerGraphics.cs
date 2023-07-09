using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace GMTKingsQueensJam2023
{
    public class ParametersControllerGraphics : MonoBehaviour
    {
        [SerializeField] private Toggle iceToggle;
        [SerializeField] private Toggle fireToggle;
        [SerializeField] private Toggle sliceToggle;
        [SerializeField] private Toggle richToggle;
        [SerializeField] private Toggle magicToggle;
        [SerializeField] private Toggle flyToggle;
        [SerializeField] private Toggle strongToggle;

        [SerializeField] private TextMeshProUGUI checkedCounterLabel;
        private int checkedCounter;

        public delegate void ParameterData(SuperParameter param, bool isChecked);
        public event ParameterData OnParameterCheckChanged;

        private Dictionary<SuperParameter, bool> parametersState;

        private void Awake()
        {
            parametersState = new Dictionary<SuperParameter, bool>
            {
                { SuperParameter.Ice, false },
                { SuperParameter.Fire, false },
                { SuperParameter.Slice, false },
                { SuperParameter.Magic, false },
                { SuperParameter.Fly, false },
                { SuperParameter.Superstrenght, false },
                { SuperParameter.Rich, false }
            };

            UpdateCheckedCounter();
        }

        private void Start()
        {
            iceToggle.onValueChanged.AddListener((bool isOn) => ToggleParameter(SuperParameter.Ice, isOn));
            fireToggle.onValueChanged.AddListener((bool isOn) => ToggleParameter(SuperParameter.Fire, isOn));
            sliceToggle.onValueChanged.AddListener((bool isOn) => ToggleParameter(SuperParameter.Slice, isOn));
            richToggle.onValueChanged.AddListener((bool isOn) => ToggleParameter(SuperParameter.Magic, isOn));
            magicToggle.onValueChanged.AddListener((bool isOn) => ToggleParameter(SuperParameter.Fly, isOn));
            flyToggle.onValueChanged.AddListener((bool isOn) => ToggleParameter(SuperParameter.Superstrenght, isOn));
            strongToggle.onValueChanged.AddListener((bool isOn) => ToggleParameter(SuperParameter.Rich, isOn));
        }

        private void ToggleParameter(SuperParameter param, bool isOn)
        {
            parametersState[param] = isOn;
            UpdateCheckedCounter();
            OnParameterCheckChanged?.Invoke(param, parametersState[param]);
        }

        private void UpdateCheckedCounter()
        {
            checkedCounter = 0;

            foreach (var (parameter, isChecked) in parametersState)
            {
                if (isChecked)
                {
                    checkedCounter++;
                }
            }

            checkedCounterLabel.text = $"[{checkedCounter}/3]";
        }
    }
}
