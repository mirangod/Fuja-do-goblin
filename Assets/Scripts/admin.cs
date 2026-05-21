using UnityEngine;
using TMPro;
using System;
using Unity.Services.Analytics;

public class admin : MonoBehaviour
{
    public GameObject player;

    private bool gameRunning = false;

    private float tempo = 0f;
    private float melhorTempo = 0f;

    public Animator tempoAnim;

    public int mortes = 0;

    private void Start()
    {
        GameObject.Find("Mortes").GetComponent<TextMeshProUGUI>().text = 
            string.Format("Mortes: {0}", mortes);
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null && Input.GetMouseButtonDown(0))
        {
            gameRunning = true;
            
            GameObject.Find("Feedback").GetComponent<TextMeshProUGUI>().text = "";

            Instantiate(player, Vector3.zero, Quaternion.identity);
        } else if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            gameRunning = false;
        }

        if (gameRunning)
        {
            tempo += Time.deltaTime;

            TimeSpan _tempo = TimeSpan.FromSeconds(tempo);

            GameObject.Find("Tempo").GetComponent<TextMeshProUGUI>().text = 
                string.Format("Seu tempo: {0:00}:{1:00}",
                _tempo.Minutes, _tempo.Seconds);
        }
    }

    public void PlayerMorreu(Collider2D collision)
    {
        switch (collision)
        {
            case var _ when collision.CompareTag("Círculo"):
                if (tempo < melhorTempo || melhorTempo == 0f)
                {
                    melhorTempo = tempo;
                }
                GameObject.Find("Melhor Tempo").GetComponent<TextMeshProUGUI>().text = 
                    string.Format("Melhor tempo: {0:00}:{1:00}",
                    TimeSpan.FromSeconds(melhorTempo).Minutes, 
                    TimeSpan.FromSeconds(melhorTempo).Seconds);
                tempoAnim.SetTrigger("vitoria");
                tempo = 0f;

                CustomEvent winEvent = new CustomEvent("player_win");

                winEvent["morte"] = mortes;

                AnalyticsService.Instance.RecordEvent(winEvent);
                break;
            case var _ when collision.CompareTag("Goblin"):
                mortes++;
                GameObject.Find("Mortes").GetComponent<TextMeshProUGUI>().text = 
                    string.Format("Mortes: {0}", mortes);
                tempoAnim.SetTrigger("derrota");

                CustomEvent loseEvent = new CustomEvent("player_lose");

                loseEvent["morte"] = mortes;

                AnalyticsService.Instance.RecordEvent(loseEvent);
                break;
        }
    }
}
