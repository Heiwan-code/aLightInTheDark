using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectLight : MonoBehaviour
{
    [SerializeField] private CollisionDetection lightUnit;
    private OrbController orbController;
    // Start is called before the first frame update
    void Start()
    {
		orbController = GetComponent<OrbController>();
	}

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetButtonDown("Fire1") && lightUnit.collided)
        {
            if ( lightUnit.unit.GetComponent<LightStrength>().growing )
            {
                lightUnit.unit.GetComponent<LightStrength>().growing = false;
                orbController.addOrb();

            } else
            {
				lightUnit.unit.GetComponent<LightStrength>().growing = true;
				orbController.removeOrb();
			}
		}
	}
}
