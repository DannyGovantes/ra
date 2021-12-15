using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class GameMenu : Menu<GameMenu>
{

   public void OnSpawnItem(){
        RecipieController.Instance.SpawnItem();
    }


}
