using UnityEngine;
using System.Collections;

public class GameButtonPause : MonoBehaviour
{
    [SerializeField]
    GameManager manager;
    [SerializeField]
    private string nameScene;

    void OnMouseDown()
    {
        if (this.enabled)
        {
            if (nameScene != "")
                Application.LoadLevel(nameScene);
            else
            {
                manager.Pause();
            }
        }
    }
}
