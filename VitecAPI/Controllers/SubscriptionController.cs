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
    public class SubscriptionController : ControllerBase
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

        // GET: api/subscription/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subscription>> GetSubscription(int id) {
            var subscription = await _context.Subscription.FindAsync(id);

            if (subscription == null) {
                return NotFound();
            }

            return subscription;
        }
        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Subscription>> PostProduct(Subscription subscription) {
            _context.Subscription.Add(subscription);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubscription", new { id = subscription.ID }, subscription);
        }

        [HttpDelete]
        public async Task<ActionResult<Subscription>> DeleteSubscription(int id) {
            var subscripion = await _context.Subscription.FindAsync(id);
            if (subscripion == null) {
                return NotFound();
            }

            _context.Subscription.Remove(subscripion);
            await _context.SaveChangesAsync();

            return subscripion;
        }
    }
}

