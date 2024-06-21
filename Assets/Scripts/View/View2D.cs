using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View2D : View
{
   

    protected override void Spawn()
    {
        int k = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                var miniFieldInst = Instantiate(_prefabCell, new Vector3(-3.7f + j * 3.2f, 3.2f - i * 3.2f, 0), Quaternion.identity);
                MiniFieldController miniField = miniFieldInst.GetComponent<MiniFieldController>(); 
                miniField.ID = k + 1;
                _miniFields[k] = miniField;
                k++;
            }
        }
    }

    protected override void OnCellPressed(int minifieldID, int cellID)
    {
        _presenter.OnCellPressed(minifieldID, cellID);
    }

    public override void MarkCell(int minifieldID, int cellID, Player player)
    {
        _miniFields[minifieldID - 1].Cells[cellID - 1].Mark(player.Team);
    }

    public override void MarkMiniField(int minifieldID, Player player)
    {
        _miniFields[minifieldID - 1].Mark(player.Team);
    }

    public override void ActivateMiniField(int minifieldID)
    {
        _miniFields[minifieldID - 1].Activate();
    }

    public override void DeactivateMiniField(int minifieldID)
    {
        _miniFields[minifieldID - 1].Deactivate();
    }
}
