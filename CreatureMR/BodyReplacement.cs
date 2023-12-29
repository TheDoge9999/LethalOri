using ModelReplacement;
using UnityEngine;

namespace CreatureModelReplacement
{

    public class BodyReplacement : BodyReplacementBase
    {

        protected override GameObject LoadAssetsAndReturnModel()
        {
            //Replace with the Asset Name from your unity project 
            string model_name = "orimodel";
            GameObject model = Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);

            Material replacementMat;

            switch (StartOfRound.Instance.unlockablesList.unlockables[controller.currentSuitID].unlockableName)
            {

                case "OriOrange":
                    replacementMat = Assets.MainAssetBundle.LoadAsset<Material>("orange");
                    break;
                case "OriGreen":
                    replacementMat = Assets.MainAssetBundle.LoadAsset<Material>("green");
                    break;
                case "OriYellow":
                    replacementMat = Assets.MainAssetBundle.LoadAsset<Material>("yellow");
                    break;
                case "OriBlue":
                    replacementMat = Assets.MainAssetBundle.LoadAsset<Material>("blue");
                    break;
                default:
                    replacementMat = Assets.MainAssetBundle.LoadAsset<Material>("orange");
                    break;
            }

            SkinnedMeshRenderer[] meshes = model.GetComponentsInChildren<SkinnedMeshRenderer>();

            Debug.Log("Looking for meshes...");
            foreach (SkinnedMeshRenderer mesh in meshes)
            {
                Debug.Log("Found a mesh: " + mesh.name);
                //mesh.materials[0].SetTexture("_BaseColorMap", replacementMat);
                mesh.SetMaterial(replacementMat);
            }

            return model;
        }


    }
}