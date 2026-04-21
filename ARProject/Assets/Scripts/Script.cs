using UnityEngine;
using TMPro; // Optionnel : pour afficher la distance sur un texte 3D

public class DistanceCalculator : MonoBehaviour
{
    [Header("Paramètres")]
    public Transform playerCamera; 
    public TextMeshPro distanceText;
    void Start()
    {
       
        if (playerCamera == null)
        {
            playerCamera = Camera.main.transform;
        }
    }

    void Update()
    {
        if (playerCamera != null)
        {
            
            float distance = Vector3.Distance(transform.position, playerCamera.position);

           
            Debug.Log($"Distance au cube : {distance.ToString("F2")} mètres");

          
            if (distanceText != null)
            {
                distanceText.text = $"Distance: {distance.ToString("F2")}m";
                distanceText.transform.rotation = Quaternion.LookRotation(distanceText.transform.position - playerCamera.position);
            }

            
            UpdateVisuals(distance);
        }
    }

    void UpdateVisuals(float dist)
    {
        Renderer renderer = GetComponentInChildren<MeshRenderer>();
        if (dist < 1.5f) // Moins d'un mètre
        {
            renderer.material.color = Color.red;
        }
        else
        {
            renderer.material.color = Color.white;
        }
    }
}