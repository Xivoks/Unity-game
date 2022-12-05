
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public Material material;
    public AudioSource sound;
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            collisionInfo.gameObject.GetComponent<MeshRenderer>().material=material;
            sound.PlayOneShot(sound.clip);
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
