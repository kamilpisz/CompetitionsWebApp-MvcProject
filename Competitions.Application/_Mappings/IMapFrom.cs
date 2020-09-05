using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Competitions.Application._Mappings
{
    public interface IMapFrom<T> where T : class
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
