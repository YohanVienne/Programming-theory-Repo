using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolePoint : MonoBehaviour
{
    public int pointReward;
    private GameManager gameManager;

    void Start() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();    
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Get Ball !");
        if (other.gameObject.CompareTag("Ball"))
        {
            gameManager.updateScore(pointReward);
        }
    }
}
