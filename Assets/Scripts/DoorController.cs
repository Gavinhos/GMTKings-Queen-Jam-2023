using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Transform leftCameraPos;
    [SerializeField] private Transform rightCameraPos;

    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        float doorPos = transform.position.x;
        float playerPos = other.transform.position.x;

        bool isGoingRight = playerPos < doorPos;

        StartCoroutine(AnimateCamera(isGoingRight ? rightCameraPos : leftCameraPos));
    }

    private IEnumerator AnimateCamera(Transform targetCameraPos)
    {
        yield return camera.transform
        .DOMove(targetCameraPos.position, 1f)
            .SetEase(Ease.InOutQuart);
    }
}
