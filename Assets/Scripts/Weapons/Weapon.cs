using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IWeapon
{
    void Fire();
}

public class Weapon : MonoBehaviour, IWeapon
{
    protected AudioSource shootSound;

    public Transform originPoint;
    public GameObject hitDecal;

    Recoil recoil;

    public virtual void Fire()
    {
        recoil.RecoilFire();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        shootSound = GetComponent<AudioSource>();
        recoil = GameObject.FindGameObjectWithTag("Recoil").GetComponent<Recoil>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void ShootBullet(Vector3 direction)
    {
        RaycastHit hit;

        if (Physics.Raycast(originPoint.position, direction, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(originPoint.position, direction * hit.distance, Color.yellow);
            Debug.Log("hit: " + hit.collider.gameObject.name);

            Instantiate(hitDecal, hit.point, Camera.main.transform.rotation);
        }
        else
        {
            Debug.DrawRay(originPoint.position, direction * 1000, Color.white);
            Debug.Log("miss");
        }
    }
}
