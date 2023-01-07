using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightStrength : MonoBehaviour
{
    public bool growing;
    private Light2D unitLight;
    private float baseIntensity;
    public float initIntensity;
    // Start is called before the first frame update
    void Start()
    {
		unitLight = GetComponent<Light2D>();
		if ( initIntensity > 0 )
		{
			baseIntensity = initIntensity;
		} else
		{
			baseIntensity = unitLight.intensity;
		}
		InvokeRepeating("StrengthRange", 0, 0.015F);
	}

    private void StrengthRange ()
    {
        if ( growing )
        {
            if ( unitLight.intensity < baseIntensity )
            {
                unitLight.intensity += 0.089F;
            }
        } else
        {
			if ( unitLight.intensity >= baseIntensity / 2 )
			{
				unitLight.intensity -= 0.089F;
			}
		}
    }
}
