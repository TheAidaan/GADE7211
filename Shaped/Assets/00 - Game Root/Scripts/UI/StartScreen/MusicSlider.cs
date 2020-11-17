using UnityEngine.UI;
using UnityEngine;

public class MusicSlider : MonoBehaviour
{
    void Start()
    {
        GetComponent<Slider>().value = SoundManager.MusicVolume;
    }
}
