using UnityEngine;

public class Coin : MonoBehaviour
{
    private AudioSource coinSound;

    private void Start()
    {
        // Procura o objeto "GetCoin" e pega o AudioSource dele
        coinSound = GameObject.Find("GetCoin").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Toca o som de coleta
            coinSound.Play();

            // Destroi a moeda após tocar o som
            Destroy(gameObject);

            // Incrementa o score
            GameManager.score += 1;
        }
    }
}
