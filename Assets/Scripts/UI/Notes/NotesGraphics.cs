using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GMTKingsQueensJam2023
{
    public class NotesGraphics : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Button closeButton;

        [SerializeField] private ParametersControllerGraphics parametersController;
        [SerializeField] private SuspectsControllerGraphics suspectsController;

        private bool isOpen;

        private void Awake()
        {
            closeButton.onClick.AddListener(Close);
        }

        private void Start()
        {
            suspectsController.Setup(parametersController);
        }
        
        public void CustomOnMouseEnter()
        {
            if (isOpen)
            {
                return;
            }

            animator.Play("Tease-in");
        }

        public void CustomOnMouseExit()
        {
            if (isOpen)
            {
                return;
            }

            animator.Play("Tease-out");
        }

        public void CustomOnMouseClicked()
        {
            if (isOpen)
            {
                return;
            }

            isOpen = true;
            animator.Play("Open");
        }

        public void Close()
        {
            StartCoroutine(CloseRoutine());
        }

        private IEnumerator CloseRoutine()
        {
            animator.Play("Close");
            yield return new WaitForSeconds(.3f);
            isOpen = false;
        }
    }
}