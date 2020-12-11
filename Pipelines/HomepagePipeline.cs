using Kentico.Kontent.Delivery.Abstractions;
using Kentico.Kontent.Statiq.Lumen.Models;

namespace Kentico.Kontent.Statiq.Lumen.Pipelines
{
    public class HomepagePipeline : LoadDataPipeLine<Homepage>
    {
        public HomepagePipeline(IDeliveryClient deliveryClient) : base(deliveryClient)
        {
        }
    }
}