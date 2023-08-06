

using Microsoft.AspNetCore.SignalR;
using OpenCvSharp;
using Grpc.Net.Client;
using Grpc.Core;
using AvideoStream;

namespace BlazorGrpcVideoStreamClient.Hubs
{
	public class GrpcClientHub : Hub
	{
		public async Task GetAndSendVideoData()
		{
			var channel = GrpcChannel.ForAddress("http://localhost:50052");
			var client = new BvideoStreamP.BvideoStreamPClient(channel);
			var request = new ServerActivity{ IsServerActive = true};
			using var call = client.RpcN(request);
			var responseStream = call.ResponseStream;
			Console.WriteLine("sa");
			await foreach (var laneValue in responseStream.ReadAllAsync())
			{
				byte[] laneBytes = laneValue.FrameData.ToByteArray();
				await Clients.All.SendAsync("ReceiveVideoByte", laneBytes);
			}
		}
	}
}