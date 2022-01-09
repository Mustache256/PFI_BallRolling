using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Script used to save player volume setting and apply them upon a new scene being loaded
public class SetVolume : MonoBehaviour
{
  //Variables that store the effects and music volume slider objects
  public Slider effects, music;
  //Function used for setup on loading a scene
  void Start()
  {
    //Setting the value of both the effects and music sliders to the stored playerprefs value, ensuring consistent volume between scenes
    effects.value = PlayerPrefs.GetFloat("EffectsVolume");
    music.value = PlayerPrefs.GetFloat("MusicVolume");
  }
  //Function used to changed the stored playerprefs value for effects volume, function is called whenever the value of the slider itself is changed by the player
  public void SetEffectsLevel(float sliderValue)
  {
    //Setting stored value to new value passed into function
    PlayerPrefs.SetFloat("EffectsVolume", sliderValue);
  }
  //Function used to changed the stored playerprefs value for music volume, function is called whenever the value of the slider itself is changed by the player
  public void SetMusicLevel(float sliderValue)
  {
    //Setting stored value to new value passed into function
    PlayerPrefs.SetFloat("MusicVolume", sliderValue);
  }
}
