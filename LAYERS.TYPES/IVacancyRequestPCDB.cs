﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAYERS.TYPES
{
    public interface IVacancyRequestPCDB
    {   
        //Shivani
        List<IVacancyRequestPC> read(IPlacementConsultant placementconsultant);
        //Shivani
    }
}
