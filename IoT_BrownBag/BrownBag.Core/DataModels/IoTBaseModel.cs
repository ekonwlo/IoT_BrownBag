using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Common.IoT.Core.DataModels
{

    //[BsonDiscriminator(RootClass = true)]
    public class IoTBaseModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        internal protected IoTBaseModel() : base() {}
    }
}
