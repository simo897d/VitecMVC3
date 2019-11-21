using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VitecAPI.Models;

namespace VitecAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController
    {
        private readonly VitecAPIContext _context;
        public SubscriptionController(VitecAPIContext context)
        {
            _context = context;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subscription>>> GetSubscription()
        {
            return await _context.Subscription.ToListAsync();
        }
    }
}
}
