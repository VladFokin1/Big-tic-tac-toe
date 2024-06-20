using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Model 
{
    protected View _view;

    public Model(View view)
    {
        _view = view;
    }

    public abstract void SetCellState(int fieldID, int cellID);
}
