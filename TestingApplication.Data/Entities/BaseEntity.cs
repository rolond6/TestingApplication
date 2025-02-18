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
        private int _id;

        public int Id { get => _id; }
        public BaseEntity() 
        {
        }
        public BaseEntity(int id) 
        {
            _id = id;
        }
    }
}
