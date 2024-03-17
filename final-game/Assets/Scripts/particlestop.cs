using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class particlestop : MonoBehaviour
{
    
    public KeyCode etkilesimTusu = KeyCode.E; // Etkile�im tu�u

    private bool oyuncuYakin = false; // Oyuncunun objenin yan�nda olup olmad���n� tutan de�i�ken

    void Update()
    {
        // E�er oyuncu objenin yan�ndaysa ve etkile�im tu�una bas�ld�ysa
        if (oyuncuYakin && Input.GetKeyDown(KeyCode.E))
        {
            // Objeyi inaktif hale getir
            gameObject.SetActive(false);
        }
    }

    // Oyuncu objeye girdi�inde
    private void OnTriggerEnter(Collider other)
    {
        // E�er �arp��an obje oyuncuysa
        if (other.CompareTag("Player"))
        {
            oyuncuYakin = true; // Oyuncu objenin yan�nda
        }
    }

    // Oyuncu objeden ��kt���nda
    private void OnTriggerExit(Collider other)
    {
        // E�er �arp��an obje oyuncuysa
        if (other.CompareTag("Player"))
        {
            oyuncuYakin = false; // Oyuncu objenin yan�nda de�il
        }
    }
}






