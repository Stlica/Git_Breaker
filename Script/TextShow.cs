using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextShow : MonoBehaviour
{
    public TextMeshProUGUI text;

    public GameObject player1;  // Reference to Player1 GameObject

    P_Controller_Platform player1Controller;

    void Start()
    {
        text.enabled = false;

        // If the TextMeshProUGUI component is not set, get it from the parent GameObject
        if (text == null)
        {
            text = GetComponent<TextMeshProUGUI>();
        }

        if (text == null)
        {
            Debug.LogError("TextMeshProUGUI is not assigned and not found on the GameObject.");
            return;
        }

        if (player1 != null)
        {
            player1Controller = player1.GetComponent<P_Controller_Platform>();
        }
    }

    void Update()
    {
        if (player1Controller.isParth && !player1Controller.isShow)
        {
            // Show the text if player1Controller.isParth is true
            text.enabled = true;
        }
        else
        {
            // Hide the text if player1Controller.isParth is false
            text.enabled = false;
        }
    }
}
