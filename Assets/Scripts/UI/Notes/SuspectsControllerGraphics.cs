using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace GMTKingsQueensJam2023
{
    public class SuspectsControllerGraphics : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI YasuoLabel;
        [SerializeField] private TextMeshProUGUI IronmanLabel;
        [SerializeField] private TextMeshProUGUI BatmanLabel;
        [SerializeField] private TextMeshProUGUI SupermanLabel;
        [SerializeField] private TextMeshProUGUI RicarditoLabel;
        [SerializeField] private TextMeshProUGUI AjaxLabel;
        [SerializeField] private TextMeshProUGUI IceQueenLabel;
        [SerializeField] private TextMeshProUGUI HulkLabel;
        [SerializeField] private TextMeshProUGUI ATrainLabel;
        [SerializeField] private TextMeshProUGUI HawkWomanLabel;

        [SerializeField] private List<SuperheroConfig> suspectsList;

        private ParametersControllerGraphics parametersController;

        public void Setup(ParametersControllerGraphics parametersController)
        {
            this.parametersController = parametersController;
            parametersController.OnParameterCheckChanged += OnParameterChanged;
        }

        private void OnParameterChanged(SuperParameter param, bool isParameterOn)
        {
            int remainingSuspects = 10;
            TextMeshProUGUI lastSuspectCandidate = null;

            foreach (var suspect in suspectsList)
            {
                var heroLabel = GetHeroLabel(suspect.hero);
                var hasAlibi = false;

                foreach (var activeParam in parametersController.GetActiveParameters())
                {
                    if (!suspect.DoFulfillParameter(activeParam))
                    {
                        hasAlibi = true;
                        remainingSuspects--;
                        Debug.Log($"{suspect.hero} has an alibi. Remaining suspects: {remainingSuspects}");
                        heroLabel.text = $"<s>{heroLabel.GetParsedText()}</s>";
                        break;
                    }
                }

                if (!hasAlibi)
                {
                    lastSuspectCandidate = heroLabel;
                    heroLabel.text = heroLabel.GetParsedText();
                }
            }

            Debug.Log($"Remaining suspects: {remainingSuspects}");
            if (remainingSuspects == 1)
            {
                lastSuspectCandidate.text = $"<mark=#ffff0055>{lastSuspectCandidate.text}</mark>";
            }
        }

        public TextMeshProUGUI GetHeroLabel(Superhero hero)
        {
            return hero switch
            {
                Superhero.Yasuo => YasuoLabel,
                Superhero.Ironman => IronmanLabel,
                Superhero.Batman => BatmanLabel,
                Superhero.Superman => SupermanLabel,
                Superhero.Ricardito => RicarditoLabel,
                Superhero.Ajax => AjaxLabel,
                Superhero.IceQueen => IceQueenLabel,
                Superhero.Hulk => HulkLabel,
                Superhero.ATrain => ATrainLabel,
                Superhero.HawkWoman => HawkWomanLabel,
                _ => null
            };
        }
    }
}
