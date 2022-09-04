using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class Decal_Fade : MonoBehaviour
{
    public float lifeTime = 3f;
    public float fadeRate = 1f;

    [Tooltip("The fade factor at which the decal gets erased")]
    [Range(0,1)]
    public float eraseThreshold;

    float timeStamp;

    DecalProjector decal;


    // Start is called before the first frame update
    void Start()
    {
        decal = GetComponent<DecalProjector>();
        timeStamp = Time.time + lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time>timeStamp)
        {
            decal.fadeFactor -= Mathf.Lerp(0, decal.fadeFactor, fadeRate * Time.deltaTime);
            if (decal.fadeFactor < eraseThreshold)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
