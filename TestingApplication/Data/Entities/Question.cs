﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities.Interfaces;

namespace TestingApplication.Data.Entities
{
    internal class Question : IQuestion
    {
        public Guid Id => throw new NotImplementedException();

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid TypeId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
