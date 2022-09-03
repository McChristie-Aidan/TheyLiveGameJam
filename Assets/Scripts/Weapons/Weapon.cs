using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IWeapon
{
    void Fire();
}

public class Weapon : MonoBehaviour, IWeapon
{
    public Transform originPoint;
    public GameObject hitDecal;

    public virtual void Fire()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
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

            Instantiate(hitDecal, hit.point, this.transform.rotation);
        }
        else
        {
            Debug.DrawRay(originPoint.position, direction * 1000, Color.white);
            Debug.Log("miss");
        }
    }
}
