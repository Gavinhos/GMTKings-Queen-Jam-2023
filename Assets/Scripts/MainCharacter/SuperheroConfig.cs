using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace GMTKingsQueensJam2023
{
    [CreateAssetMenu(menuName = "Game Configs/Superhero")]
    public class SuperheroConfig : ScriptableObject
    {
        public Superhero hero;
        public string description;

        public bool usesIce;
        public bool usesFire;
        public bool slicesThings;
        public bool usesMagic;
        public bool flies;
        public bool hasSuperStrenght;
        public bool isRich;

        public bool DoFulfillParameter(SuperParameter param)
        {
            return param switch
            {
                SuperParameter.Ice => usesIce,
                SuperParameter.Fire => usesFire,
                SuperParameter.Slice => slicesThings,
                SuperParameter.Magic => usesMagic,
                SuperParameter.Fly => flies,
                SuperParameter.Superstrenght => hasSuperStrenght,
                SuperParameter.Rich => isRich,
                _ => false
            };
        }
    }
}
