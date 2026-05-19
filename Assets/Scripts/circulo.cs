using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class circulo : MonoBehaviour
{
    public LineRenderer cir;
    private int resolution = 100;
    public float raio = 4f;

    private void Start()
    {
        DrawCircle();

        EdgeCollider2D edgeCollider = GetComponent<EdgeCollider2D>();

        Vector2[] pontos = new Vector2[resolution];

        float angle = 0f;

        for (int i =0 ;i < resolution; i++)
        {
            float x = raio * Mathf.Cos(angle);
            float y = raio * Mathf.Sin(angle);

            pontos[i] = new Vector2(x, y);

            angle += 2f * Mathf.PI / resolution;
        }

        edgeCollider.points = pontos;
    }

    void DrawCircle()
    {
        cir.loop = true;
        cir.positionCount = resolution;

        float angle = 0f;

        for (int i = 0; i < resolution; i++)
        {
            float x = raio * Mathf.Cos(angle);
            float y = raio * Mathf.Sin(angle);
            cir.SetPosition(i, new Vector3(x, y, 0f));
            angle += 2f * Mathf.PI / resolution;
        }
    }
}
