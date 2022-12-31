using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{

    private Transform player;
    private Transform enemy;
    private Rigidbody2D rb;
    public float shadowPower;
    public float moveSpeed;
    public bool follow;
    private Vector3 playerCords;
    private Vector3 enemyCords;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
		enemy = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        if ( !follow )
        {
			playerCords = player.position;
			enemyCords = enemy.position;

			Vector3 diff = playerCords - enemyCords;
            diff = diff.normalized;
			Vector2 push = new Vector2(diff.x * moveSpeed, diff.y * moveSpeed);

			rb.AddForce(push);
		} 
	}

    // Update is called once per frame
    void Update()
    {
        if ( follow )
        {
            playerCords = player.position;
            enemyCords = enemy.position;

            Vector3 diff = playerCords - enemyCords;
            print(Mathf.Sign(Mathf.Floor(diff.x)) * moveSpeed);
            Vector2 push = new Vector2(Mathf.Sign(Mathf.Floor(diff.x)) * moveSpeed, Mathf.Sign(Mathf.Floor(diff.y)) * moveSpeed);
            
            rb.AddForce(push);
        }
	}
}
