using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gpsGame : MonoBehaviour
{
    public Material material;
    public float targetLat;
    public float targetLon;
    public TextMeshProUGUI laty;
    public TextMeshProUGUI longi;
    public TextMeshProUGUI dist;
    private float oldDistance;
    public float maxDistance=100;

    IEnumerator Start()
    {
        if (!Input.location.isEnabledByUser)
            yield break;

        Input.location.Start(1f,1f);

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait < 1)
        {
            Debug.Log("Timed out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }
    }
    private string GetDistanceClues(float distance)
    {
        // Define distance thresholds for clues
        float closeThreshold = 10f;
        float moderateThreshold = 50f;

        // Provide text clues based on distance
        if (distance < closeThreshold)
        {
            return "Very Close!!!";
        }
        else if (distance < moderateThreshold)
        {
            return "You are kinda close";
        }
        else if (distance < 100)
        {
            return "You are In the Area";
        }
        else if (distance < 150)
        {
            return "You are fairly far ";
        }
        else
        {
            return "You are too Far Away";
        }
    }
    void Update()
    {
        
        float playerLat = Input.location.lastData.latitude;
        float playerLon = Input.location.lastData.longitude;
        longi.text = "longitude= " + playerLon;
        laty.text = "latitude= " + playerLat;
        Debug.Log(playerLat+"  "+ playerLon);
        float newDistance = CalculateDistance(playerLat, playerLon, targetLat, targetLon);
        dist.text = GetDistanceClues(newDistance);
        material.color=CalculateColor(newDistance);

       
    }
    public void ManualUpdate()
    {
        // Trigger a manual GPS update
        Input.location.Stop();
        Input.location.Start(1f, 1f);

    }
    public Color CalculateColor(float distance)
    {
        // Map distance to a color spectrum (blue to red)
        float normalizedDistance = Mathf.Clamp01(distance / maxDistance);
        return Color.Lerp(Color.red, Color.blue, normalizedDistance);
    }
    public float CalculateDistance(float lat1, float lon1, float lat2, float lon2)
    {
        return(Mathf.Sqrt((lat2-lat1)*(lat2-lat1)+ (lon2 - lon1) * (lon2 - lon1))* 111320f);
    //    float R = 6371; // Radius of the earth in km
    //    float dLat = (lat2 - lat1) * Mathf.Deg2Rad;
    //    float dLon = (lon2 - lon1) * Mathf.Deg2Rad;
    //    float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
    //        Mathf.Cos(lat1 * Mathf.Deg2Rad) * Mathf.Cos(lat2 * Mathf.Deg2Rad) *
    //        Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);
    //    float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
    //    float d = R * c; // Distance in km
    //    return d;
    }
}
