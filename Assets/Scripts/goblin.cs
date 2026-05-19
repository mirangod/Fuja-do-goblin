using UnityEngine;

public class goblin : MonoBehaviour
{
    public Transform centro;
    public float speed;

    float radius;

    private void Start()
    {
        radius = centro.localScale.x * 0.5f;
    }

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        if (player != null)
        {
            Vector3 dir = player.transform.position - centro.position;
            dir.Normalize();

            Vector3 _dir = centro.position + dir * radius;

            float dis = Vector3.Distance(transform.position, _dir);
            float rot = speed / dis;

            transform.position = Vector3.RotateTowards(transform.position, _dir, rot * Time.deltaTime, 0f);
        }
    }
}
