using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OrbController : MonoBehaviour
{
	public GameObject orb;
    public float radius;
	public float random;
    private List<GameObject> orbsList;

	public float rotateSpeed;
	private float prevAngle;

	private Vector2 smoothPosition;
	// Start is called before the first frame update
	void Start()
    {
		orbsList = new List<GameObject>();
		InvokeRepeating("RotateOrbs", 0, 0.03F);
		//addOrb();
	}

    private void RotateOrbs ()
    {
		Vector3 v3Pos = Input.mousePosition;
		v3Pos.z = ( this.transform.position.z - Camera.main.transform.position.z );

		v3Pos = Camera.main.ScreenToWorldPoint(v3Pos);

		v3Pos = v3Pos - this.transform.position;
		float angle = Mathf.Atan2(v3Pos.y , v3Pos.x) * Mathf.Rad2Deg;
		if ( angle < 0F )
			angle += 360F;

		if ( orbsList.Count > 0 )
		{
			foreach ( GameObject xOrb in orbsList )
			{
				//xOrb.transform.parent = this.transform;
				xOrb.transform.localEulerAngles = new Vector3(0, 0, angle);
				float xPos = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
				float yPos = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;

				float xPosPrev = Mathf.Cos(Mathf.Deg2Rad * prevAngle) * radius;
				float yPosPrev = Mathf.Sin(Mathf.Deg2Rad * prevAngle) * radius;

				Vector2 targetPos = new Vector2(this.transform.position.x + xPos * random, this.transform.position.y + yPos * random);

				Vector2 oldPos = new Vector2(this.transform.position.x + xPosPrev * random, this.transform.position.y + yPosPrev * random);


				smoothPosition = Vector2.Lerp(oldPos, targetPos, rotateSpeed);
				xOrb.transform.localPosition = smoothPosition;
				//xOrb.GetComponent<Rigidbody2D>().MovePosition(smoothPosition);
			}
		}
		prevAngle = angle;

	}


	public void addOrb ()
    {
        GameObject newOrb = Instantiate(orb, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);
		//newOrb.transform.parent = this.transform;
		orbsList.Add(newOrb);
		print(orbsList);
	}

	public void removeOrb ()
	{
	}
}
