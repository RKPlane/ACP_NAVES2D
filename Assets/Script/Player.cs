using UnityEngine.InputSystem;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("herencias")]

    [Header("Player Settings")]
    private Rigidbody2D rb;

    [Header("Movement Settings")]
    [SerializeField] private float speed; // poner la speed a 7
    private float moveHorizontal;
    private float moveVertical;

    [Header("Input Settings")]
    public InputActionAsset inputActions;
    private InputAction m_moveAction;
    private Vector2 m_moveAmt;

    private void OnEneable()//Se habilita el Action Map del jugador
    {
        inputActions.FindActionMap("Player").Enable();
    }
    private void OnDiseable()//Se deshabilita el Action Map del jugador
    {
        inputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        m_moveAction = InputSystem.actions.FindAction("Move");//Busca "Move" definida en el Input Action Asset
    }
    void Update()
    {
        m_moveAmt = m_moveAction.ReadValue<Vector2>();//Lee el valor del vector de los inputs
    }

    // FixedUpdate para aplicar la física
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {

        if (m_moveAmt.sqrMagnitude > 1f)
        {
            m_moveAmt.Normalize();//Normaliza el vector para que la velocidad diagonal no sea mayor a la speed establecida
        }
        rb.linearVelocity = m_moveAmt * speed;
        ////print(m_moveAmt);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            GameOver();
            
            //Player Color
            SpriteRenderer playerRenderer = GetComponent<SpriteRenderer>();
            if (playerRenderer != null)
            {
                playerRenderer.material.SetColor("_Color", Color.red);
            }

            //Target que mi hitea color
            MeshRenderer targetRenderer = collision.gameObject.GetComponent<MeshRenderer>();
            if (targetRenderer != null)
            {
                targetRenderer.material.SetColor("_Color", Color.yellow);
            }
        }
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");

        // Detener el tiempo para la memoria
        Time.timeScale = 0f;

        //TODO Futuro
        // SceneManager.LoadScene("GameOverScene");
    }
}
