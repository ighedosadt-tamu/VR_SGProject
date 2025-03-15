using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectTransformation : MonoBehaviour
{
    [Header("XR Input Actions")]
    [Description("2D vector for the left thumbstick to move an object.")]
    public InputActionProperty leftJoystick;
    [Description("2D vector for the right thumbstick to turn an object.")]
    public InputActionProperty rightJoystick;
    
    [Header("Joystick Movement Settings")]
    public float translationSpeed = 0.5f;
    public float rotationSpeed = 25f;

    public void TransformObject()
    {
        Vector2 left_stick = leftJoystick.action.ReadValue<Vector2>();
        Vector2 right_stick = rightJoystick.action.ReadValue<Vector2>();

        Debug.Log(left_stick);
        // Translate (XZ plane) with LEFT stick
        Vector3 current_position = transform.position;
        Vector3 target = new Vector3(current_position.x + left_stick.y, current_position.y, current_position.z + (left_stick.x * -1));

        transform.position = Vector3.MoveTowards(current_position, target, Time.deltaTime * translationSpeed);

        // Rotate (Around Y-Axis) with RIGHT stick
        float yaw = right_stick.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(0f, yaw, 0f, Space.Self);
    
    }
    
    
}