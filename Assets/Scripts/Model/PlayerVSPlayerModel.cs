using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVSPlayerModel : Model
{

    public PlayerVSPlayerModel(View view) : base(view)
    {

    }

    public override void SetCellState(int fieldID, int cellID)
    {
        if (_IsWin) return;
        DoMove(fieldID, cellID);
        NextTurn();

    }


    public override void NextTurn()
    {
        ChangeTurn();
    }



}
