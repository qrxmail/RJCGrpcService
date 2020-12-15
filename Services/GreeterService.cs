using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace RJCGrpcService
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                //Message = CollectOilStationDataService.Instance.GetDemoPLC() 
                Message = "Hello " + request.Name
            });
        }

        public override Task<StationData> GetStationFieldData(StationName request, ServerCallContext context)
        {
            //return base.GetStationFieldData(request, context);
            return Task.FromResult(new StationData
            {
                //Message = CollectOilStationDataService.Instance.GetDemoPLC() 
                Data = "获取站点数据： " + request.Name
            });
        }

        public override Task<ControlResult> WriteStation(ControlModel request, ServerCallContext context)
        {
            //var service = CollectOilStationDataService.Instance;
            //var controlTag = ControlHelp.GetControlTagByRequest(request.Target, request.Action);

            //service.WritePLCTag("tianchang93", controlTag.TagInfo, controlTag.newValue);
            //return Task.FromResult(new ControlResult { Result = "OK" });
            return Task.FromResult(new ControlResult
            {
                //Message = CollectOilStationDataService.Instance.GetDemoPLC() 
                Result = "发送站点指令： " + request.Action
            });
        }
    }
}
