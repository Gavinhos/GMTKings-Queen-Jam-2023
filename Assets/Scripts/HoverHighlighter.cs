using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class HoverHighlighter : MonoBehaviour
{
    private Color startcolor;

    void OnMouseEnter()
    {
        startcolor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = startcolor;
    }
}