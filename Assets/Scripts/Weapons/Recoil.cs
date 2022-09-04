using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{

    Vector3 currentRot;
    Vector3 targetRot;

    //hipfire
    [SerializeField] private float recoilX =-2f;
    [SerializeField] private float recoilY =2f;
    [SerializeField] private float recoilZ =.35f;

    //settings 
    [SerializeField] private float snapiness = 6f;
    [SerializeField] private float returnSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetRot = Vector3.Lerp(targetRot, Vector3.zero, returnSpeed * Time.deltaTime );
        currentRot = Vector3.Slerp(currentRot, targetRot, snapiness * Time.fixedDeltaTime);

        transform.localRotation = Quaternion.Euler(currentRot);
    }

    public void RecoilFire()
    {
        targetRot += new Vector3(
            recoilX,
            Random.Range(-recoilY,recoilY),
            Random.Range(-recoilZ,recoilZ));
    }
}
