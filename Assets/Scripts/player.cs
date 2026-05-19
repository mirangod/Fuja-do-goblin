using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    Vector3 target;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0f;
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        } else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Círculo"))
        {
            GameObject.Find("Feedback").GetComponent<TextMeshProUGUI>().text = "VOCÊ GANHOU!";

            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Goblin"))
        {
            GameObject.Find("Feedback").GetComponent<TextMeshProUGUI>().text = "VOCÊ PERDEU!";

            Destroy(this.gameObject);
        }
    }
}
