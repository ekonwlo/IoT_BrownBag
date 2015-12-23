using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Common.IoT.Core.DataModels
{
    
    public class IotDeviceModel
        : IoTBaseModel
    {

        public string DevideId { get; set; }
        public string DevideName { get; set; }

        public GeoJson2DGeographicCoordinates Coordinates { get; set; }

        [BsonConstructor()]
        public IotDeviceModel() : base() { }

    }
}
