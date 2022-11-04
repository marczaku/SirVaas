using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
[ExecuteAlways]
public class AspectRatioFitter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    void Start()
    {
        if(_camera == null)
            _camera = GetComponent<Camera>();
    }

    void Update()
    {
        if (IsInLandscapeMode())
        {
            _camera.orthographicSize = 4.5f;
        }
        else
        {
            _camera.orthographicSize = 4.5f * Screen.height / Screen.width;
        }
    }

    bool IsInLandscapeMode() => Screen.width >= Screen.height;
}
