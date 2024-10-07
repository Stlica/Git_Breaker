using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class P2_TextShow : MonoBehaviour
{
    public TextMeshProUGUI text;

    public GameObject player2;  // Reference to Player2 GameObject

    P2_Controller_Platform player2Controller;

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

        if (player2 != null)
        {
            player2Controller = player2.GetComponent<P2_Controller_Platform>();
        }
    }

    void Update()
    {
        if (player2Controller.isParth && !player2Controller.isShow)
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
