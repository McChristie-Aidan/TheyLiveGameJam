using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sway : MonoBehaviour
{
    public float intensity =1f;
    public float smooth =1f;

    public float tiltIntensity = 2f;

    private Quaternion originPos;

    private void Start()
    {
        originPos = transform.localRotation;
    }

    private void Update()
    {
        UpdateSway();
    }
    private void UpdateSway()
    {
        float mouseX = 0, mouseY = 0;

        var delta = Mouse.current.delta.ReadValue() / 15.0f;
        mouseX += delta.x;
        mouseY += delta.y;

        Quaternion xAdjustment = Quaternion.AngleAxis(intensity * -mouseX,Vector3.up);
        Quaternion yAdjustment = Quaternion.AngleAxis(intensity * mouseY,Vector3.right);
        Quaternion zAdjustment = Quaternion.AngleAxis(tiltIntensity * -mouseX, Vector3.forward);
        Quaternion targetRot = originPos * xAdjustment * yAdjustment * zAdjustment;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRot, Time.deltaTime * smooth);
    }
}
