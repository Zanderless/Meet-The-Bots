/**
 * @file       : Entity.cs
 * @author     : Jakob P.
 * @description: The script that handles all weapon logic
 * @note       : This script belongs on the actual gun/fps arms prefab
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MTB {

    public static class Json {
        
        /**
         * @brief   Load Json data
         */
        public static T LoadData<T>(string path) {

            TextAsset text = Resources.Load(path) as TextAsset;

            try
            {
                return JsonUtility.FromJson<T>(text.text);
            }
            catch
            {
                Debug.LogError("Cannot find file from path \n" + path);
            }

            return default(T);

        }

        /**
         * @brief   Store Json data
         */
        public static void StoreData() {

            //Saves Data to a Json file using JsonUtility.ToJson

        }
    }
}