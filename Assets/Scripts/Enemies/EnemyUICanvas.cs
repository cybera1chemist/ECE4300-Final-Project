using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUICanvas : MonoBehaviour
{
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        transform.rotation = mainCamera.transform.rotation;
    }
}
