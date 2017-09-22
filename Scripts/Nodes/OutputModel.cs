﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Graphmesh {
    public class OutputModel : GraphmeshNode {

        protected override void Init() {
            name = "Output Model";
            inputs = new NodePort[1];
            inputs[0] = CreateNodeInput("Model", typeof(List<Model>));
        }

        public List<Model> GetModels() {
            return GetOutputValue(0) as List<Model>;
        }

        public override object GenerateOutput(int outputIndex, object[][] inputs) {
            List<Model> models = UnpackModels(0, inputs);

            for (int i = 0; i < models.Count; i++) {
                models[i].mesh.RecalculateBounds();
            }

            return UnpackModels(0, inputs);
        }
    }
}