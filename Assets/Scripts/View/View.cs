using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class View : MonoBehaviour
{
    protected Presenter _presenter;
    protected GameObject _prefabCell;
    protected MiniFieldController[] _miniFields;
    protected GameObject _textMoveObj;
    protected TMP_Text _textCurrentMove;
    protected GameObject _textWinObj;
    protected TMP_Text _textWin;

    public void Init(
        Presenter presenter, 
        GameObject prefabCell,
        GameObject textMoveObj,
        TMP_Text textCurrentMove,
        GameObject textWinObj,
        TMP_Text textWin
        )
    {
        _miniFields = new MiniFieldController[9];
        _presenter = presenter;
        _prefabCell = prefabCell;
        _textMoveObj = textMoveObj;
        _textCurrentMove = textCurrentMove;
        _textWin = textWin;
        _textWinObj = textWinObj;

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

    public abstract void ChangeTurnText(Team team);

}
