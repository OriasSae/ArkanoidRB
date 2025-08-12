using UnityEngine;

public class PlayerBoardScript : MonoBehaviour
{

    public Rigidbody2D rb2D;

    private float Inputvalue;

    public float moveSpeed = 70;

    private Vector2 direction;
    
    Vector2 startPos;



// Start is called once before the first execution of Update after the MonoBehaviour is created
private void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Inputvalue = Input.GetAxisRaw("Horizontal");

        if (Inputvalue == 1)
        {
            direction = Vector2.right;
        }
        else if (Inputvalue == -1)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.zero;
        }

        rb2D.AddForce(direction * moveSpeed * Time.deltaTime * 75);

        // Aqui intente hacer el control horizontal mediante transform y RigidBody de muchas formas y seguia dando error, al final tuve que cambiar las playersettings en Unity para que acepte el metodo de input.
        // Tambi�n tuve problema con el RigidBody por que la variable RigidBody2D la nombr� igual y Unity la interpretaba diferente.
    }
    public void ResPly()
    {
        transform.position = startPos;
        rb2D.linearVelocity = Vector2.zero;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PowerUp PU))
        {
            PU.Collide();
        }
    }
}
