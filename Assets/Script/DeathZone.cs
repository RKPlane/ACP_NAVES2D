using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Target"))
        {
            GameOver();
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
