using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;

public class cloud : MonoBehaviour
{
    async void Start()
    {
        await UnityServices.InitializeAsync();

        AnalyticsService.Instance.StartDataCollection();

        Debug.Log("Analytics inicializado.");
    }
}
