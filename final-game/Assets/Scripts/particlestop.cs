using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class particlestop : MonoBehaviour
{
    
    public KeyCode etkilesimTusu = KeyCode.E; // Etkileþim tuþu

    private bool oyuncuYakin = false; // Oyuncunun objenin yanýnda olup olmadýðýný tutan deðiþken

    void Update()
    {
        // Eðer oyuncu objenin yanýndaysa ve etkileþim tuþuna basýldýysa
        if (oyuncuYakin && Input.GetKeyDown(KeyCode.E))
        {
            // Objeyi inaktif hale getir
            gameObject.SetActive(false);
        }
    }

    // Oyuncu objeye girdiðinde
    private void OnTriggerEnter(Collider other)
    {
        // Eðer çarpýþan obje oyuncuysa
        if (other.CompareTag("Player"))
        {
            oyuncuYakin = true; // Oyuncu objenin yanýnda
        }
    }

    // Oyuncu objeden çýktýðýnda
    private void OnTriggerExit(Collider other)
    {
        // Eðer çarpýþan obje oyuncuysa
        if (other.CompareTag("Player"))
        {
            oyuncuYakin = false; // Oyuncu objenin yanýnda deðil
        }
    }
}






