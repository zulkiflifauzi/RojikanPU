﻿using RojikanPU.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojikanPU.Logic.Interface
{
    public interface IPPKFileLogic : IBaseLogic<PPKFile>
    {
        List<PPKFile> GetPPKFiles(int articleId);
    }
}
