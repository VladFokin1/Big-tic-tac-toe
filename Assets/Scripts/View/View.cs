using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class View : MonoBehaviour
{
    protected Presenter _presenter;
    protected GameObject _prefabCell;
    protected MiniFieldController[] _miniFields;

    public void Init(Presenter presenter, GameObject prefabCell)
    {
        _miniFields = new MiniFieldController[9];
        _presenter = presenter;
        _prefabCell = prefabCell;
        Spawn();
        for (int i = 0; i < 9; i++)
            _miniFields[i].Pressed += OnCellPressed;
    }


    protected abstract void Spawn();

    protected abstract void OnCellPressed(int minifieldID, int cellID);

    public abstract void MarkCell(int minifieldID, int cellID, Player player);

    public abstract void MarkMiniField(int minifieldID, Player player);

    public abstract void ActivateMiniField(int minifieldID);
    public abstract void DeactivateMiniField(int minifieldID);

}
