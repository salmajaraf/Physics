using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holderCollision : MonoBehaviour
{
    private bool moveRight = true; // Variable pour suivre l'état du mouvement du holder

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("holder"))
        {
            Debug.Log("A Collision with the holder has occurred");
            // Appliquer une force avec une direction dépendant de l'état du mouvement du holder
            if (moveRight)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(200, 400, 1)); // Vers la droite
            }
            else
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(-200, 400, 1)); // Vers la gauche
            }
            // Inverser l'état du mouvement pour la prochaine collision
            moveRight = !moveRight;
        }
        else if (collision.gameObject.CompareTag("cube"))
        {
            Debug.Log("A collision with a cube has occurred");
            // Vous pouvez accéder à la position du cube en collision
            Vector3 cubePosition = collision.gameObject.transform.position;
            Debug.Log("Collided cube position: " + cubePosition);
            // Détruire le cube
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("wall") || collision.gameObject.CompareTag("wall2"))
        {
            Debug.Log("A collision with a wall has occurred");
            // Appliquer une force ou prendre d'autres mesures selon les besoins
            float forceMagnitude = 220f;
            float forceDirectionX = moveRight ? 1f : -1f;
            GetComponent<Rigidbody>().AddForce(new Vector3(forceDirectionX * forceMagnitude, 150, 1));
        }
        else if (collision.gameObject.CompareTag("plan")) // If ball hits the boundary
        {
            Debug.Log("Ball fell off, restarting game.");
            Destroy(gameObject); // Destroy the ball
        }
    }
}
