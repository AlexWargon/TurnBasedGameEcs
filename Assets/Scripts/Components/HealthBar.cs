using TMPro;
using UnityEngine;
using UnityEngine.UI;

[EcsComponent]
public sealed class HealthBar {
    public Transform view;
    public Slider slider;
    public TextMeshProUGUI text;
}