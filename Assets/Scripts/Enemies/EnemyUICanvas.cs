using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyUICanvas : MonoBehaviour
{
    private Camera mainCamera;
    
    void Start()
    {
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        transform.rotation = mainCamera.transform.rotation;
    }
}
