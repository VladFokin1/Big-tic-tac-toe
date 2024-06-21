using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardPresenter : Presenter
{
    public StandardPresenter(Model model) : base(model)
    {
    }

    public override void OnCellPressed(int minifieldID, int cellID)
    {
       _model.SetCellState(minifieldID, cellID);
       _model.NextTurn();
    }
}
