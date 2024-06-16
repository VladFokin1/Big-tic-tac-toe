using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _prefabCell;
    [SerializeField] private View2D _viewPrefab;


    private void Awake()
    {
        View view = Instantiate(_viewPrefab);
        Model model = new StandardRulesModel(view);
        Presenter presenter = new StandardPresenter(model);

        view.Init(presenter, _prefabCell);
        //view.Spawn();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
