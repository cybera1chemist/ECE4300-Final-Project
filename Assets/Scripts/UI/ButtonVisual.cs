using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonVisual : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField] private Material normalMaterial;
    [SerializeField] private Material hoveredMaterial;
    [SerializeField] private Material clickedMaterial;

    [SerializeField] private GameObject button;

    private MeshRenderer rd;

    private void Start()
    {
        rd = button.GetComponent<MeshRenderer>();
    }

    public void OnHovered()
    {
        rd.material = hoveredMaterial;
    }

    public void OnHoverLeave()
    {
        rd.material = normalMaterial;
    }

    public void OnClick()
    {
        Debug.Log("Button clicked.");
        rd.material = clickedMaterial;
    }

    public void OnClickLeave()
    {
        rd.material = normalMaterial;
    }
}
