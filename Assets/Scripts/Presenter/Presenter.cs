using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Presenter
{
    protected Model _model;
    
    public Presenter(Model model)
    {
        _model = model;
    }
}
