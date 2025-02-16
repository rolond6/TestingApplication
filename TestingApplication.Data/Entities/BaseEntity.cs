using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities.Interfaces;

namespace TestingApplication.Data.Entities
{
    public abstract class BaseEntity: IIdentifiableEntity
    {
        private byte[] _id;

        public byte[] Id { get => _id; set => _id = value; }
        public BaseEntity() 
        {
            _id = NewId.NextGuid().ToByteArray();
        }
        public BaseEntity(byte[] id) 
        {
            _id = id;
        }
    }
}
