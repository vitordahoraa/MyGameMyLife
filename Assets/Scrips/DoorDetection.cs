using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DoorDetection : MonoBehaviour
{
    // Start is called before the first frame update
    private bool doorAllowed;
    public string Scene;

    public TextMeshProUGUI Error;
    public void OnTriggerEnter2D(Collider2D collider){
        doorAllowed = Input.GetButton("DoorScene");
        if(collider.CompareTag("Player") && doorAllowed){
            SceneManager.LoadScene(Scene);
        }
    }
}
