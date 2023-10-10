using UnityEngine;

public class BigBirdMovements : MonoBehaviour
{
    private Animator animator;
    private bool isGrounded;
    private bool isFalling;

    public Vector3 initialPosition;
    private float speed = 6f;
    private float maxSpeed = 100f;
    private float maxHeight ;
    private bool movingDown = true;
    private float waitTime = 2f;
    private float waitTimer = 0f;

    private void Start()
    {
        initialPosition = transform.position;
        maxHeight = initialPosition.y + 3f;
        animator = GetComponent<Animator>();

    }

    private void Update()
    {

        // Mettre à jour les paramètres de l'Animator
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("isFalling", isFalling);

        // Déterminer l'état d'animation à jouer
        if (isGrounded)
        {
            animator.Play("BirdIsGrounded");
        }
        else if (isFalling)
        {
            animator.Play("BirdFall");
        }
        else
        {
            animator.Play("BirdIdle");
        }
        
        // Déplacer le poulet
        if (movingDown)
        {
            // Accélérer le poulet
            speed = Mathf.Min(speed + Time.deltaTime, maxSpeed);
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            OnFalling();

            if (transform.position.y <= 0f)
            {
                movingDown = false;
                OnGrounded();
            }
        }
        else
        {
            // Réinitialiser la vitesse
            speed = 6f;

            transform.position = Vector3.MoveTowards(transform.position, initialPosition, speed * Time.deltaTime);
            OnFlying();

            if (transform.position.y >= maxHeight)
            {
                movingDown = true;

            }
        }

      
            // Ajout de la condition pour relancer le script
        if (transform.position == initialPosition && !movingDown)
        {
            movingDown = true;
        }

    }
     // Appelé lorsque le joueur touche le sol
    public void OnGrounded()
    {
        isGrounded = true;
        isFalling = false;
    }

    // Appelé lorsque le joueur commence à tomber
    public void OnFalling()
    {
        isGrounded = false;
        isFalling = true;
    }

    // Appelé lorsque le joueur s'envole
    public void OnFlying()
    {
        isGrounded = false;
        isFalling = false;

    }
}
