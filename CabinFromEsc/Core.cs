using MelonLoader;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[assembly: MelonInfo(typeof(CabinFromEsc.Core), "CabinFromPause", "1.0.0", "fabbeyond", null)]
[assembly: MelonGame("TraipseWare", "Peaks of Yore")]

namespace CabinFromEsc
{
    public class Core : MelonMod
    {
        string lastCabin = "-";

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName == "Cabin") lastCabin = "MainCabin";
            else if (sceneName == "Category4_1_Cabin") lastCabin = "NorthernCabin";
            else if (sceneName == "Alps_Main") lastCabin = "AlpsCabin";
            else if (sceneName == "TitleScreen") ;
            else
            {
                GameObject quitButton = GameObject.Find("Canvas/InGameMenu/InGameMenuObj_DisableMe/menu_pg/MenuContainer/Quit");
                GameObject cabinButton = GameObject.Instantiate(quitButton, quitButton.transform.parent);
                cabinButton.name = "Cabin";
                cabinButton.transform.SetSiblingIndex(3);
                GameObject.Find("Canvas/InGameMenu/InGameMenuObj_DisableMe/menu_pg/MenuContainer/Cabin/Text").GetComponent<Text>().text = "Cabin";
                UnityEngine.UI.Button cabinButtonBtn = cabinButton.GetComponent<UnityEngine.UI.Button>();

                cabinButtonBtn.onClick.RemoveAllListeners();
                cabinButtonBtn.onClick.AddListener(GoToCabin);
            }
        }

        void GoToCabin()
        {
            if (lastCabin != "-")
            {
                if (lastCabin == "MainCabin")
                {
                    GameManager.control.Save();
                    SceneManager.LoadSceneAsync("Cabin");

                }
                else if (lastCabin == "NorthernCabin")
                {
                    GameManager.control.Save();
                    SceneManager.LoadSceneAsync("Category4_1_Cabin");
                }
                else if (lastCabin == "AlpsCabin")
                {
                    GameManager.control.Save();
                    SceneManager.LoadSceneAsync("Alps_Main");
                }
                GameObject.Find("QuitConfirmDialog").SetActive(false);
            }
        }
    }
}