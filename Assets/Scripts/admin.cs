using UnityEngine;
using TMPro;

public class admin : MonoBehaviour
{
    public GameObject player;

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null && Input.GetMouseButtonDown(0))
        {
            GameObject.Find("Feedback").GetComponent<TextMeshProUGUI>().text = "";

            Instantiate(player, Vector3.zero, Quaternion.identity);
        }
    }
}
