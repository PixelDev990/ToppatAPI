using ToppatAPI.Map;
using ToppatAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ToppatAPI.Builders
{
    interface Builder
    {
        /**
         *  Builds MapAsset before ShipStatus.OnEnable
         */
        public bool PreBuild(MapAsset asset);

        /**
         *  Wraps up every up after ShipStatus.OnEnable
         */
        public bool PostBuild();
    }
}
