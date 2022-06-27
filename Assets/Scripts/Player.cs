using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float maxJumpHeight;
	public float timeToJumpApex;
	//float accelerationTimeAirborne;
	//float accelerationTimeGrounded;
	float moveSpeed;

	float gravity;
	float maxJumpVelocity;

	Vector3 velocity;
	//float velocityXSmoothing;
	public float targetVelocityX;

	Controller2D controller;

	public int direction;

	public bool isMoving;

	float velocityXSmoothing;
	float accelerationTime;

	void Start()
	{
		controller = GetComponent<Controller2D>();

		moveSpeed = 8;
		maxJumpHeight = 3;
		timeToJumpApex = 0.5f;
		//accelerationTimeAirborne = 0.2f;
		//accelerationTimeGrounded = 0.1f;

		//equações para que com as variáveis de jump height e time to jump apex, seja possível chegar na gravidade e velocidade 
		//de pulo, já que esses não são números fáceis de se imaginar
		//gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);

		//valor de gravidade testado 
		gravity = -55;
		maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		print("Gravity: " + gravity + "  Jump Velocity: " + maxJumpVelocity);
		isMoving = false;
		accelerationTime = 0.05f;
	}

	void Update()
	{
		direction = controller.direction;	

		//se o jogador estiver colidindo com alguma coisa em seu eixo y, setamos a velocidade em y para 0, para que quando ele caia, a velocidade em y não acumule
		if (controller.collisions.above || controller.collisions.below)
		{
			velocity.y = 0;
		}

		if (controller.jump)
		{
			jump();
		}

		
		if (Input.GetKey(KeyCode.X))
		{
			targetVelocityX = direction * moveSpeed;
			isMoving = true;
		}
		
		else if (!Input.GetKey(KeyCode.S))

		{
			targetVelocityX = 0;
			isMoving = false;
        }

		if (!controller.isGrounded)
		{
			accelerationTime = 0.5f;
		}
        else
        {
			accelerationTime = 0.05f;
        }

		//para que a velocidade não mude repentinamente, usamos smoothdamp para que a velocidade atual mude para a nova de maneira suave
		//definimos a velocidade final que se quer alcançar na variavel abaixo

		//no primeiro parametro esta a velocidade atual, no segundo a velocidade que se quer atingir, e em quarto a aceleração
		//nesse caso, ? seria um if e : seria um else, desse modo, se o jogador esta colidindo com o chao, a aceleração será a do chão, e caso contrario, será a do ar

		velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, accelerationTime);
		//velocity.x = targetVelocityX;
        

		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);
	}

	public void jump()
    {

		velocity.y = maxJumpVelocity;

		controller.jump = false;
		
	}

}
