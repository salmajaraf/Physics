using UnityEngine;

public class BallHolderMovement : MonoBehaviour
{
    /*public float moveSpeed = 5f; // Vitesse de déplacement
    public float boundaryX = 5f; // Limite horizontale du déplacement

    void Update()
    {

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
    }

    void MoveLeft()
    {
        // Calcul du déplacement vers la gauche
        Vector3 movement = Vector3.left * moveSpeed * Time.deltaTime;
        // Limiter le mouvement pour rester dans les limites horizontales
        if (transform.position.x - movement.x > -4)
        {
            transform.Translate(movement); 
        }
    }

    void MoveRight()
    {
        Vector3 movement = Vector3.right * moveSpeed * Time.deltaTime;
        if (transform.position.x + movement.x < 4)
        {
            transform.Translate(movement); 
        }
    }*/
    public float speed = 8f; // Ajustez la vitesse du mouvement si nécessaire
    // public float maxX = 14f; // Ajustez la position maximale sur l'axe X
    public float minX = 6f; // Ajustez la position minimale sur l'axe X


    void Update()
    {
        // Calcul du mouvement sur l'axe X
        float movementX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        // Calcul de la nouvelle position sur l'axe X
        float newXPosition = Mathf.Clamp(transform.position.x + movementX, -minX, minX);

        // Mise à jour de la position seulement sur l'axe X
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
    }
}