using UnityEngine;
using UnityEngine.UI;

public class StaminaBarUI : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private PlayerController player;

    private void LateUpdate()
    {
        if (player == null || fillImage == null)
            return;

        fillImage.fillAmount = player.StaminaNormalized;
    }
}