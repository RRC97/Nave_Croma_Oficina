using UnityEngine;
using System.Collections;

public class GameButtonPause : MonoBehaviour
{
    [SerializeField]
    GameManager manager;
    [SerializeField]
    private string nameScene;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = BackgroundColor.invertColorText;
    }

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
