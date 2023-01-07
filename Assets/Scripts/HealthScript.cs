using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HealthScript:MonoBehaviour
{

    private UnitStats unit;
    private Animator anim;
    public Transform healthBar;
    private Light2D light;
    private float maxLight;

    // Start is called before the first frame update
    void Start ()
    {
        unit = GetComponent<UnitStats>();
        anim = GetComponent<Animator>();
        light = GetComponent<Light2D>();
        maxLight = light.intensity;
    }

    // Update is called once per frame
    void Update ()
    {
        float percentHp = unit.currentHealth / unit.maxHealth;
        light.intensity = percentHp * maxLight;
		healthBar.localScale = new Vector3(percentHp, 1, 1);
		if ( unit.currentHealth <= 0 )
        {
            anim.SetBool("dead", true);
        }

	}
}
