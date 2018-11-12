using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using zadatak9.Models;
using Microsoft.EntityFrameworkCore;
using zadatak9.Proxy;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace zadatak9.Controllers
{
    [Route("api/Security")]
    public class SecurityController : Controller
    {
        private readonly DataContext _context;

        public SecurityController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Security> list = new List<Security>();
            List<SecurityProxy> proxyList = new List<SecurityProxy>();
            list = _context.Securities.Include(x => x.Exchange)
                                       .Include(x => x.Security_Primary_Type)
                                       .Include(x => x.Currency).ToList();
            foreach (var item in list)
            {
                var securityProxy = CreateProxy(item);
                proxyList.Add(securityProxy);
            }

            return Ok(proxyList);
        }

        [HttpGet("{id}")]
        public IActionResult GetSecurity(string id)
        {
            
            var security = _context.Securities
                      .Include(x => x.Currency)
                      .Include(x => x.Exchange)
                      .Include(x => x.Security_Primary_Type)
                      .Include(x => x.UnderlyningSecurity)
                      .FirstOrDefault(x => x.SID == id);

            if (security == null)
            {
                return BadRequest();
            }

            var securityProxy = CreateProxy(security);

            return Ok(securityProxy);
        }

        [HttpPost("search")]
        public IActionResult Search([FromBody] SecurityQuery searchQuery)
        {
            List<SecurityProxy> ProxyList = new List<SecurityProxy>();
            try
            {
                IEnumerable<Security> resultSet = _context.Securities.Include(x => x.Currency)
                                                                     .Include(x => x.Exchange)
                                                                     .Include(x => x.Security_Primary_Type)
                                                                     .Where(searchQuery.Compile());

                if (resultSet.Count() == 0)
                {
                    return NotFound("No records found");
                }
                else
                {
                    foreach (var item in resultSet)
                    {
                        SecurityProxy securityProxy = CreateProxy(item);
                        ProxyList.Add(securityProxy);
                    }

                    return Ok(ProxyList);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private static SecurityProxy CreateProxy(Security item)
        {
            CurrencyProxy currencyProxy = new CurrencyProxy()
            {
                Id = item.Currency_ID,
                Description = item.Currency.Description
            }; 

            ExchangeProxy exchangeProxy = new ExchangeProxy()
            {
                Id = item.Exchange_ID,
                Description = item.Exchange.Description
            };

            Security_Primary_TypeProxy securityPrimaryTypeProxy = new Security_Primary_TypeProxy()
            {
                Id = item.Security_Primary_Type_ID,
                Description = item.Security_Primary_Type.Description
            };

            SecurityProxy securityProxy = new SecurityProxy()
            {
                Sid = item.SID,
                Ticker = item.Ticker,
                Description = item.Description,
                Start_Date = item.Start_Date,
                End_Date = item.End_Date,
                Currency = currencyProxy,
                Underlyning_Sid = item.Underlyning_SID,
                Exchange = exchangeProxy,
                Security_Primary_Type = securityPrimaryTypeProxy
            };

            return securityProxy;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] SecurityProxy s)
        {
            Security security = new Security()
            {
                SID = s.Sid,
                Ticker = s.Ticker,
                Description = s.Description,
                Start_Date = s.Start_Date,
                End_Date = s.End_Date,
                Currency_ID = s.Currency.Id,
                Underlyning_SID = s.Underlyning_Sid,
                Exchange_ID = s.Exchange.Id,
                Security_Primary_Type_ID = s.Security_Primary_Type.Id
            };

            _context.Securities.Add(security);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("edit")]
        public IActionResult Edit([FromBody] SecurityProxy s)
        {
            Security security = _context.Securities.FirstOrDefault(x => x.SID == s.Sid);
            if (security == null)
            {
                return BadRequest();
            }

            security.Ticker = s.Ticker;
            security.Description = s.Description;
            security.Start_Date = s.Start_Date;
            security.End_Date = s.End_Date;
            security.Currency_ID = s.Currency.Id;
            security.Underlyning_SID = s.Underlyning_Sid;
            security.Exchange_ID = s.Exchange.Id;
            security.Security_Primary_Type_ID = s.Security_Primary_Type.Id;

            _context.Securities.Update(security);
            _context.SaveChanges();

            return Ok();
        }
    }
}
