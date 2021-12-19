using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHealth : MonoBehaviour
{
    Player player;
    TextMeshProUGUI healthText;

    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();
    }


    void Update()
    {
        healthText.text = player.GetHealth().ToString();
    }
}
