using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider Slider;

    public void SetMaxHealth(int health)
    {
        Slider.maxValue = health;
        Slider.value = health;
    }
    public void SetMinHealth(int health)
    {
        Slider.minValue = health;
    }
}

