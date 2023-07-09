using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotesGraphics : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Button closeButton;

    private bool isOpen;

    private void Awake()
    {
        closeButton.onClick.AddListener(Close);
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
