using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyect_RaceTrack.Data;
using Proyect_RaceTrack.Models;
using Proyect_RaceTrack.ViewModels.CocheraViewModels;
using Proyect_RaceTrack.Services;
using Proyect_RaceTrack.ViewModels;
using Proyect_RaceTrack.ViewModels.PistaViewModels;

namespace Proyect_RaceTrack.Controllers
{
    public class CocheraController : Controller
    {
        private ICocheraService _cocheraService;

        public CocheraController(ICocheraService cocheraService)
        {
            _cocheraService = cocheraService;
        }

    }
}
