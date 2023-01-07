using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{

    private Transform player;
    private Transform enemy;
    private Rigidbody2D rb;
    public float shadowPower;
    private float moveSpeed;
    private UnitStats unit;
    public bool follow;
    private Vector3 playerCords;
    private Vector3 enemyCords;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
		enemy = GetComponent<Transform>();
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
        unit = GetComponent<UnitStats>();
        moveSpeed = unit.speed;
        if ( !follow )
        {
			playerCords = player.position;
			enemyCords = enemy.position;

			Vector3 diff = playerCords - enemyCords;
            diff = diff.normalized;
			Vector2 push = new Vector2(diff.x * moveSpeed, diff.y * moveSpeed);

			rb.AddForce(push);
		}
        else
        {
			print("move");
			InvokeRepeating("Move", 0, 0.03F);
		}
	}

 //   // Update is called once per frame
 //   void Update()
 //   {
 //       if ( follow )
 //       {
            
 //       }
	//}

    private void Move ()
    {
		playerCords = player.position;
		enemyCords = enemy.position;
		Vector3 diff = playerCords - enemyCords;
		Vector3 diffNormalized = diff.normalized;
		if ( Mathf.Abs(diffNormalized.x) > Mathf.Abs(diffNormalized.y) )
		{
			anim.SetFloat("y", 0);
			anim.SetFloat("x", diffNormalized.x);
		} else
		{
			anim.SetFloat("x", 0);
			anim.SetFloat("y", diffNormalized.y);
		}
		Vector2 push = new Vector2(Mathf.Sign(Mathf.Floor(diff.x)) * moveSpeed, Mathf.Sign(Mathf.Floor(diff.y)) * moveSpeed);

		rb.AddForce(push);
	}
}
