using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamageTerrain : MonoBehaviour
{
	[SerializeField] private CollisionDetection collider;
	public float damage;
    // Start is called before the first frame update
    void Start()
    {
		InvokeRepeating("doDamageToTarget", 0, 0.03F);
	}

	private void doDamageToTarget ()
	{
		if ( collider.collided )
		{
			if ( collider.unit.GetComponent<UnitStats>().currentHealth > 0 && !collider.unit.GetComponent<Animator>().GetBool("dashing"))
			{
				print("touching lava");
				collider.unit.GetComponent<UnitStats>().currentHealth = collider.unit.GetComponent<UnitStats>().currentHealth - damage;
			}
		}
	}
}
