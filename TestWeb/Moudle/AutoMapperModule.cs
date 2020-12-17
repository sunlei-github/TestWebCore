using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using static WebApi.Controllers.TestController;

namespace WebApi.Moudle
{
    public class AutoMapperModule : Profile
    {

        public AutoMapperModule()
        {
            CreateMap<People, ChinesePeople>();
        }

    }
}
