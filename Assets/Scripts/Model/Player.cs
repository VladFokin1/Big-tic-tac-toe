using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{

    protected Team _team;
    public Team Team { get { return _team; } }

    public Player(Team team)
    {
        this._team = team;
    }

}

