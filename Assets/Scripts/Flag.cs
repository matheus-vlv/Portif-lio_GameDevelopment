using UnityEngine;

public class Bandeira : MonoBehaviour
{
    public GameObject MensagemFinal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MensagemFinal.SetActive(true); // exibe a mensagem final
            Time.timeScale = 0f; // pausa o jogo (opcional)
        }
    }
}
