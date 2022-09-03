using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public int pellets = 10;
    public float spread = .1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Fire()
    {
        for (int i = 0; i < pellets; i++)
        {
            float x = Random.Range(-spread, spread);
            float y = Random.Range(-spread, spread);

            Vector3 spreadMod = new Vector3(x, y, 0);

            Vector3 forward = transform.TransformDirection(Vector3.forward + spreadMod) * 10;
            ShootBullet(forward);
        }
    }
}
