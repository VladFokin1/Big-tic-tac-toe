using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHolder 
{
    public static GameMode Mode { get; set; } = GameMode.PlayerVSPlayer;
    public static Team Team { get; set; } = Team.None;
}
