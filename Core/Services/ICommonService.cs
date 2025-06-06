﻿using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ICommonService<T, TI, TU>
    {
        public List<string> Errors { get; }
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Add(TI insertDto);
        Task<T> Update(int id, TU updateDto);
        Task<T> Delete(int id);
        bool Validate(TI insertDto);
        bool Validate(TU updateDto);
    }
}
