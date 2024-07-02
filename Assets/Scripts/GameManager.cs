using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _prefabCell;
    [SerializeField] private View2D _viewPrefab;
    [SerializeField] private GameObject _textMoveObj;
    [SerializeField] private TMP_Text _textCurrentMove;
    [SerializeField] private GameObject _textWinObj;
    [SerializeField] private TMP_Text _textWin;
    //[SerializeField] private GameMode _gameMode;

    private void Awake()
    {
        View view = Instantiate(_viewPrefab);
        Model model = null;
        switch (DataHolder.Mode)
        {
            case GameMode.PlayerVSPlayer:
                model = new PlayerVSPlayerModel(view);
                break;
            case GameMode.PlayerVSComputer:
                model = new PlayerVSComputerModel(view);
                break;
        }
        Presenter presenter = new StandardPresenter(model);

        view.Init(presenter, _prefabCell, _textMoveObj, _textCurrentMove, _textWinObj, _textWin);
        //view.Spawn();

    }
}
