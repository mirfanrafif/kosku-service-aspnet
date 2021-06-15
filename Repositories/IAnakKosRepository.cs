﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kosku.Data.Entities;

namespace Kosku.Repositories
{
    public interface IAnakKosRepository
    {
        public List<AnakKos> GetAll();

        public void Add(AnakKos anakKos);

        public Task<AnakKos> Find(int id);

        public Task<AnakKos> Update(int id, AnakKos anakKos);

        public Task<AnakKos> Delete(int id);

    }
}
