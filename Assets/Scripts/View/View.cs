using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class View : MonoBehaviour
{
    protected Presenter _presenter;
    protected GameObject _prefabCell;
    protected MiniFieldController[] miniFields;

    public void Init(Presenter presenter, GameObject prefabCell)
    {
        _presenter = presenter;
        _prefabCell = prefabCell;
        miniFields = new MiniFieldController[9];
        Spawn();
    }

    /* protected abstract void SpawnMiniField(Vector3 startPos);


     protected abstract void SpawnField(Vector3 startPos);*/

    private void Spawn()
    {
        int k = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                MiniFieldController miniField = Instantiate(_prefabCell, new Vector3(-3.7f + j * 3.2f, 3.2f - i * 3.2f, 0), Quaternion.identity).GetComponent<MiniFieldController>();
                miniField.ID = k + 1;
                miniFields[k] = miniField;
                k++;
            }
        }
    }

}
