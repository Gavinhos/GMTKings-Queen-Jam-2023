using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent aiController;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Camera mainCamera;
    private Transform t;

    void Start()
    {
        mainCamera = Camera.main;
        t = transform;
    }

    void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            return;
        }

        RaycastHit hit;
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            spriteRenderer.flipX = hit.point.x < t.position.x;
            aiController.SetDestination(hit.point);
        }
    }
}
