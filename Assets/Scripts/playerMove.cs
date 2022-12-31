using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{

    private Transform playerTransform;
    private Rigidbody2D playerRb;
    private Vector3 movement;
	private SpriteRenderer playerSprite;
    public float dashCooldownF = 0.12F;
    public bool dashAvailable = true;
    public float movespeed = 5F;
    public float dashSpeed = 2.3F;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal") * 0.03F ,Input.GetAxis("Vertical") * 0.03F);
		playerRb.AddForce(new Vector2(movement.x * movespeed, movement.y * movespeed), ForceMode2D.Impulse);

        useDash();
    }

    void useDash ()
    {
		if ( Input.GetButtonDown("Jump") && dashAvailable )
		{
			var m_NewColor = new Color(0.95F, 0.01F, 0.01F, 1F);
			playerSprite.color = m_NewColor;
            playerRb.drag = 40;
			playerRb.AddForce(new Vector2(movement.x * 900F * dashSpeed, movement.y * 900F * dashSpeed), ForceMode2D.Impulse);
			StartCoroutine(DashCooldown());
		}
	}

	public IEnumerator DashCooldown ()
	{
        Debug.Log("Cooldown start");
		dashAvailable = false;
		yield return new WaitForSeconds(dashCooldownF);
		dashAvailable = true;
        playerRb.drag = 65;
		playerSprite.color = new Color(0.9F, 0.9F, 0.9F, 1F);
		Debug.Log("Cooldown end");
	}
}
