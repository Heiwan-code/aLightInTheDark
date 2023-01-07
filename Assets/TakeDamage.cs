using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
	[SerializeField] private CollisionDetection collider;
	private UnitStats stats;
	private float damage;
	// Start is called before the first frame update
	void Start()
    {
		damage = collider.unit.GetComponent<UnitStats>().damage;
		InvokeRepeating("takeTamage", 0, 0.03F);
		stats = GetComponent<UnitStats>();
	}

	private void takeTamage ()
	{
		if ( collider.collided )
		{
			stats.currentHealth = stats.currentHealth - damage;
			if ( stats.currentHealth <= 0 )
			{
				Object.Destroy(this.gameObject);
			}
		}
	}
}
