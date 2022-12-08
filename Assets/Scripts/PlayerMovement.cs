using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    static int timeScale = 1;
    public Rigidbody rb;
    public float forwardForce = 3000f;
    public float sidewaysForce = 500f;

    void FixedUpdate()
    {
        float speed = forwardForce / timeScale;
        Debug.Log(speed);
        rb.AddForce(0, 0, speed * Time.deltaTime);
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "SlowDown")
        {
            timeScale = 2;
        }

        if (collisionInfo.collider.tag == "BoostUp")
        {
            timeScale = 1;
        }
        if (collisionInfo.collider.tag == "Respawn")
        {
            timeScale = 1;
            float speed = forwardForce / timeScale;
        }
        if (collisionInfo.collider.tag == "Jump")
        {
            rb.AddForce(0, 7f, 0, ForceMode.VelocityChange);
        }
    }
}