using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Door : MonoBehaviour
{
    [Header("Door Settings")]
    public Sprite closedDoor;
    public Sprite activeDoor;
    public string roomName;

    [Header("UI Elements")]
    public GameObject ePrompt;
    public TextMeshProUGUI roomNameText;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedDoor;

        if (ePrompt) ePrompt.SetActive(false);
        if (roomNameText) roomNameText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spriteRenderer.sprite = activeDoor;

            if (ePrompt) ePrompt.SetActive(true);
            if (roomNameText)
            {
                roomNameText.text = roomName;
                roomNameText.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spriteRenderer.sprite = closedDoor;

            if (ePrompt) ePrompt.SetActive(false);
            if (roomNameText) roomNameText.gameObject.SetActive(false);
        }
    }
}