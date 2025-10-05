using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Door Sprites")]
    public Sprite closedDoor;
    public Sprite activeDoor;

    [Header("Linked Objects")]
    public GameObject ePrompt;         // иконка "E" над игроком
    public GameObject roomLabel;       // PNG над дверью
    public FadeController fadeController;
    public GameObject currentRoom;
    public GameObject targetRoom;

    private SpriteRenderer spriteRenderer;
    private bool canInteract = false;
    private bool isTransitioning = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedDoor;

        if (ePrompt) ePrompt.SetActive(false);
        if (roomLabel) roomLabel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        spriteRenderer.sprite = activeDoor;
        canInteract = true;

        if (ePrompt) ePrompt.SetActive(true);
        if (roomLabel) roomLabel.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        spriteRenderer.sprite = closedDoor;
        canInteract = false;

        if (ePrompt) ePrompt.SetActive(false);
        if (roomLabel) roomLabel.SetActive(false);
    }

    private void Update()
    {
        if (canInteract && !isTransitioning && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(SwitchRoom());
        }
    }

    private System.Collections.IEnumerator SwitchRoom()
    {
        isTransitioning = true;

        // Плавное затемнение
        yield return fadeController.FadeOut();

        // Переключаем комнаты
        currentRoom.SetActive(false);
        targetRoom.SetActive(true);

        // Плавное появление
        yield return fadeController.FadeIn();

        isTransitioning = false;
    }
}