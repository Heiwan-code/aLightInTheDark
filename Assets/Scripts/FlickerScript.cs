using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlickerScript : MonoBehaviour
{
    public float flickerRange;
    public float flickerSpeed;
    private Light2D light;
	private static FieldInfo falloffField = typeof(Light2D).GetField("m_FalloffIntensity", BindingFlags.NonPublic | BindingFlags.Instance);
	private float baseFalloffIntensity;
    // Start is called before the first frame update
    void Start()
    {
		InvokeRepeating("Flicker", 0, 0.03F);
        light = GetComponent<Light2D>();
		baseFalloffIntensity = light.falloffIntensity;
	}

    private void Flicker ()
    {
		SetFalloff(light.falloffIntensity + flickerSpeed);
        if ( baseFalloffIntensity + flickerRange - light.falloffIntensity  <= 0 )
        {
			SetFalloff(baseFalloffIntensity);
		}
	}

	private void SetFalloff (float falloff)
	{
		falloffField.SetValue(light, falloff);
	}
}
