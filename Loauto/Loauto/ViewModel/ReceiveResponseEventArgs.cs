using static Loauto.Model.NetworkModel;
using System;

namespace Loauto.ViewModel
{
    public class ReceiveResponseEventArgs
    {
        private RESTAPI api;
        private MethodModel sendmodel;
        private object result;

        public ReceiveResponseEventArgs(RESTAPI api, MethodModel sendmodel, object result)
        {
            this.Api = api;
            this.Sendmodel = sendmodel;
            this.Result = result;
        }

        public RESTAPI Api { get => api; set => api = value; }
        public MethodModel Sendmodel { get => sendmodel; set => sendmodel = value; }
        public object Result { get => result; set => result = value; }
    }
}