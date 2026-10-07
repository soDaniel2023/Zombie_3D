using UnityEngine;
using TMPro;

public class EndGameTrigger : MonoBehaviour
{
    [SerializeField] private ScreenFader fader;
    [SerializeField] private TextMeshProUGUI endText;
    [TextArea] [SerializeField] private string message = "This house has never liked being looked at.";

    private bool fired;

    private void OnTriggerEnter(Collider other)
    {
        if (fired) return;
        if (!other.CompareTag("Player")) return;

        fired = true;

        var controller = other.GetComponent<MonoBehaviour>();
        if (controller != null) controller.enabled = false;

        if (endText != null)
        {
            endText.gameObject.SetActive(true);
            endText.text = "";
        }

        fader.FadeOut(() =>
        {
            if (endText != null) endText.text = message;
        });
    }
}