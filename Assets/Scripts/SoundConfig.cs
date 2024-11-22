using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "ScriptableObjects/SoundConfig")]
public class SoundConfig : ScriptableObject
{
    public SoundData gameMuisc;
    public SoundData menuMusic;
    public SoundData setSound;
    public SoundData grabSound;
    public SoundData chopSound;
    public SoundData rightSound;
    public SoundData wrongSound;
    public SoundData sucessSound;
    public SoundData failureSound;
    public SoundData warningSound;
    public SoundData endingSound;
    public SoundData finalSound;
    public SoundData walkSound;
    public SoundData jumpSound;

    public SoundData attackSound;

}
