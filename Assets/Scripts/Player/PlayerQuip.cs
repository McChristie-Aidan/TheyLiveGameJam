using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerQuip : MonoBehaviour
{
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnQuip(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed && gameObject.scene.IsValid())
        {
            source.Stop();
            source.Play();
        }
    }
}
