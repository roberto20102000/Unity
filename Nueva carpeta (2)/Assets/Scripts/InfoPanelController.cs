using TMPro;
using UnityEngine;

public class InfoPanelController : MonoBehaviour
{
    public GameObject infoPanel;
    public TMP_Text titleText;
    public TMP_Text infoText;

    public void ShowNucleus()
    {
        infoPanel.SetActive(true);

        titleText.text = "NÚCLEO";

        infoText.text =
            "El núcleo contiene la mayor parte " +
            "del material genético de la célula " +
            "y participa en el control de las " +
            "actividades celulares.";
    }

    public void ShowMitochondria()
    {
        infoPanel.SetActive(true);

        titleText.text = "MITOCONDRIAS";

        infoText.text =
            "Las mitocondrias participan en la " +
            "producción de ATP, una de las " +
            "principales formas de energía " +
            "utilizada por las células.";
    }

    public void ShowMembrane()
    {
        infoPanel.SetActive(true);

        titleText.text = "MEMBRANA CELULAR";

        infoText.text =
            "La membrana celular delimita la " +
            "célula y regula el intercambio de " +
            "sustancias entre el interior y " +
            "el exterior.";
    }

    public void ClosePanel()
    {
        infoPanel.SetActive(false);
    }
}