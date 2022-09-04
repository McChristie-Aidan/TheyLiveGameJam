using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGun : MonoBehaviour
{
    public float cooldownLength = 1f;
    float timeStamp;
    bool readyToFire;

    [SerializeField]
    public Weapon weapon;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeStamp && !readyToFire)
        {
            readyToFire = !readyToFire;
            Debug.Log("Ready To Fire!");
        }
    }

    public void OnFire(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed && gameObject.scene.IsValid())
        {
            if (readyToFire)
            {
                weapon.Fire();
                timeStamp = Time.time + cooldownLength;
                readyToFire = !readyToFire;
                Debug.Log("fired");
            }
            else
            {
                Debug.Log("Not Ready to fire");
            }
        }
    }
}
