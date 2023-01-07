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
    public float dashSpeed = 2.3F;
    private Animator anim;
	private UnitStats stats;
	private float moveSpeed;
	private float baseDrag;
	[SerializeField] AudioSource stepRock;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		stats = GetComponent<UnitStats>();
		moveSpeed = stats.speed;
		baseDrag = playerRb.drag;
		InvokeRepeating("Move",0 , 0.03F);
	}

	// Update is called once per frame
	void Update()
    {
		Dash();
    }

    private void Move ()
    {
		movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

		float x = movement.x;
		float y = movement.y;
        if ( Mathf.Abs(x) > Mathf.Abs(y) )
        {
			anim.SetFloat("y", 0);
            anim.SetFloat("x", x);
		} else
        {
			anim.SetFloat("x", 0);
			anim.SetFloat ("y", y);
        }

		if ( Mathf.Abs(x) > 0 || Mathf.Abs(y) > 0 )
		{
			if ( !stepRock.isPlaying )
			{
				stepRock.Play();
			}
		} else
		{
			if ( stepRock.isPlaying )
			{
				stepRock.Pause();
			}
		}
		playerRb.AddForce(new Vector2(movement.x * 0.3F * moveSpeed, movement.y * 0.3F * moveSpeed), ForceMode2D.Impulse);
	}

    private void Dash ()
    {
		if ( Input.GetButtonDown("Jump") && dashAvailable )
		{
			StartCoroutine(Dashing());
			StartCoroutine(DashCooldown());
		}
	}

	private IEnumerator Dashing ()
	{
		dashAvailable = false;
		anim.SetBool("dashing", true);
		playerRb.drag = 30;
		playerRb.AddForce(new Vector2(movement.x * 900F * dashSpeed, movement.y * 900F * dashSpeed), ForceMode2D.Impulse);
		yield return new WaitForSeconds(0.7F);
		anim.SetBool("dashing", false);
	}

	private IEnumerator DashCooldown ()
	{
		playerRb.drag = baseDrag;
		yield return new WaitForSeconds(dashCooldownF);
		dashAvailable = true;
	}
}
