using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Model.DataHero
{
    [CreateAssetMenu(menuName = "Data/hero", fileName = "HeroData")]
    public class DataWariorCollection : ScriptableObject
    {
       public List<DataWarior> dataWarrior = new List<DataWarior>(); 
       public List<DataArcher> dataArcher = new List<DataArcher>(); 
    }
}