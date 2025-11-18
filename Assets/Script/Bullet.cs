using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Sonido para mas tarde
    /*
    [Header("Sonido al impactar")]
    public AudioClip hitSound;
    private AudioSource audioSource;*/

    private void Start()
    {
        //Sonido para mas tarde
        /*
         audioSource = GetComponent<AudioSource>(); 
         */

        //Validacion hasta que hayan paredes o rigid bodys para que no explote el engine de balas infinitas por el mapa
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            Debug.Log("Objetivo");
            //Sonido para mas tarde
            /*
            if (audioSource != null && hitSound != null)
            {
                audioSource.PlayOneShot(hitSound);
            }*/

            //Cambiar color del objetivo a rojo, SpiritRenderer si uso sprites mas tarde
            MeshRenderer renderer = collision.gameObject.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                renderer.material.SetColor("_Color", Color.red);
            }

            //Destruir objetivo
            Destroy(collision.gameObject, 0.08f);
        }

        // Destruir bala
        Destroy(gameObject, 0.1f);
    }
}

