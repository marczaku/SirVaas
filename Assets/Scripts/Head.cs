using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class RotationHandler
{
    public KeyCode input;
    public Vector3 direction;
    public Transform transform;
    
    private bool hasTapped;
    public void Update()
    {
        if (Input.GetKeyDown(input))
        {
            hasTapped = true;
        }
    }
    public void FixedUpdate()
    {
        if (Input.GetKey(input) || hasTapped)
        {
            transform.Rotate(direction);
        }

        hasTapped = false;
    }
}

public class Head : MonoBehaviour
{
    // 16: 9
    // 16 : 9
    // 160 :    90 x  10 pixels
    // 1600 x  900 x 100 pixels
    // 1920 x 1080 x 120 pixels
    
    public RotationHandler[] rotationHandlers;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Pikachu pikachu))
        {
            // grow logic
            pikachu.OnEaten();
        }
    }

    void Update()
    {
        for (var i = 0; i < rotationHandlers.Length; i++)
        {
            rotationHandlers[i].Update();
        }
    }
    
    void FixedUpdate()
    {
        for (var i = 0; i < rotationHandlers.Length; i++)
        {
            rotationHandlers[i].FixedUpdate();
        }
        Vector3 position = transform.position + transform.up;
        position.x = (position.x + 13.5f) % 9 - 4.5f;
        position.y = (position.y + 13.5f) % 9 - 4.5f;
        transform.position = position;
    }
}
