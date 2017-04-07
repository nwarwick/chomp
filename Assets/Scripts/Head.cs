using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public Player player;
    // BASIC MOVEMENT VALUES
    public float topSpeed;      // maximum movement speed (when not boosting)
                                // BOOST VALUES
    public float boostCoolDown; // this is the number of seconds before the worm can boost again
    public float boostSpeed;    // how many times faster the boost carries the worm
    public float boostLength;   // how long the boost lasts
                                // INTERNAL MOVEMENT VARIABLES
    public float moveSpeed = 20;  // (this is only "public" so playerControls and AI can get at it)
                                  // INTERNAL BOOST VARIABLES
    public float coolCurrent = 0; // Made public for charge status update
    public float currentBoost = 0;
    Vector3 boostDirection;

    public bool dead = false;
    public Vector3 deadAngle = new Vector3(0f, 0f, 0f);



    void Start()
    {
        if (player == null)
        {
            player = transform.parent.gameObject.GetComponent<Player>();
        }

        // If still null then we are an AI
        if (player == null)
        {
			// Don't need to do anything (yet) because I added checks before incrementing score
        }

    }

    void FixedUpdate()
    {
        if (dead)
        {   // if dead
            gameObject.transform.position += deadAngle * Time.deltaTime; // slide in a randomly selected (by WormDie.cs) direction
            transform.Rotate(Vector3.forward * Time.deltaTime * 90f);   // rotate
            transform.localScale += new Vector3(-0.004f, -0.004f, 0);


        }
        else
        {
            if (moveSpeed > topSpeed)
                moveSpeed = topSpeed;

            if (currentBoost > boostLength - (1.0f / 4.0f))
            {   // in the first 1/4 second, we are interpolating up to full boost speed
                var accelFactor = (boostLength - currentBoost) * 4.0f;
                moveSpeed = (moveSpeed * (1.0f - accelFactor)) + ((topSpeed * boostSpeed) * (accelFactor));
            }
            else if (currentBoost > (boostLength / 2.0f))
            {   // then cruise at full boosted speed until the halfway point
                moveSpeed = topSpeed * boostSpeed;
            }
            else if (currentBoost > 0)
            {   // then interpolate back down to normal travel speed
                var decelFactor = currentBoost / (boostLength / 2.0f); // goes from 1 to 0
                moveSpeed = (moveSpeed * (1.0f - decelFactor)) + ((topSpeed * boostSpeed) * (decelFactor));
            }

            gameObject.transform.position += gameObject.transform.up * moveSpeed * Time.deltaTime;

            if (currentBoost > 0)
                currentBoost -= Time.deltaTime;
            if (currentBoost <= 0 && coolCurrent > 0)
                coolCurrent -= Time.deltaTime;
        }
    }

    public void turnTowards(Vector3 point)
    {
        if (currentBoost > boostLength - (1.0f / 4.0f))
        {
            var relativeMA = (Mathf.Atan2(point.y, point.x) * Mathf.Rad2Deg) - 90f;
            var relativeBA = boostDirection;

            if (relativeMA - relativeBA.z > 0)
            {   // turn left
                relativeBA.z += (3f * boostLength - (1.0f / 4.0f));
            }
            else
            {   // turn right
                relativeBA.z -= (3f * boostLength - (1.0f / 4.0f));
            }
            transform.rotation = Quaternion.Euler(relativeBA);

            boostDirection = gameObject.transform.eulerAngles;
        }
        else if (currentBoost > (boostLength / 2.0f))
        {
            transform.rotation = Quaternion.Euler(boostDirection);
        }
        else if (currentBoost > 0)
        {

        }
        else
        {
            var relativeMA = (Mathf.Atan2(point.y, point.x) * Mathf.Rad2Deg) - 90f;
            transform.rotation = Quaternion.Euler(0, 0, relativeMA);
        }
    }

    public void boost()
    {
        if (coolCurrent <= 0)
        {
            currentBoost = boostLength;
            coolCurrent = boostCoolDown;
            boostDirection = gameObject.transform.eulerAngles;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // If we hit food
        if (other.gameObject.tag == "Food")
        {
            Food food = other.gameObject.GetComponent<Food>();
            // If we are a player, increment score
            if (transform.parent.gameObject.tag == "Player")
            {
                player.IncrementScore(food.scoreWeight); // Increment score by 10 for food. 
            }
            food.DestroyFood(); // Eat da food
        }
        else if (other.gameObject.tag == "Body" && currentBoost > 0)
        {
            // if the worm hits a tail while boosting, it kills the worm
            if (other.transform.parent != gameObject.transform.parent)
            {   // ... assuming it's not your OWN tail
                other.transform.parent.GetComponent<WormDie>().Kill();

                // If we are a player, increment score
                if (transform.parent.gameObject.tag == "Player")
                {
                    player.IncrementScore(100); // Increment score by 100 for kills.  
                }
            }
        }
        else
        {   // if the worm hits something that doesn't give way, it loses any boost momentum
            currentBoost = 0;
        }
    }
}
