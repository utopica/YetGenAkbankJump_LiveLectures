using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week11_Assignment.Persistence.API.Models;
using Week11_Assignment.Persistence.Domain.Dtos;
using Week11_Assignment.Persistence.Domain.Entities;
using Week11_Assignment.Persistence.Infrastructure.Contexts;


namespace Week11_Assignment.Persistence.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        public AssignmentDbContext _assignmentDbContext { get; set; }

        public BankAccountsController(AssignmentDbContext assignmentDbContext)
        {
            _assignmentDbContext = assignmentDbContext;
        }

        [HttpPost("[action]")]
        public void SetDefaultUsersData()
        {
            List<BankAccount> people = new List<BankAccount>
            {
                new BankAccount
                {
                    Id = Guid.Parse("f4ee11a6-9d8e-4584-8d7f-8ad2d83119c9"),
                    CreatedOn = DateTime.UtcNow,
                    CreatedByUserId = "1",
                    FirstName = "James",
                    LastName = "Smith",
                    PhoneNumber = "5523367351"
                },
                new BankAccount
                {
                    Id = Guid.Parse("f4ee11a6-9d8e-4584-8d7f-8ad2d83119c8"),
                    CreatedOn = DateTime.UtcNow,
                    CreatedByUserId = "2",
                    FirstName = "Emily",
                    LastName = "Johnson",
                    PhoneNumber = "5523367352"
                },
                new BankAccount
                {
                    Id = Guid.Parse("f4ee11a6-9d8e-4584-8d7f-8ad2d83119c7"),
                    CreatedOn = DateTime.UtcNow,
                    CreatedByUserId = "3",
                    FirstName = "Michael",
                    LastName = "Williams",
                    PhoneNumber = "5523367353"
                },
                new BankAccount
                {
                    Id = Guid.Parse("f4ee11a6-9d8e-4584-8d7f-8ad2d83119c6"),
                    CreatedOn = DateTime.UtcNow,
                    CreatedByUserId = "4",
                    FirstName = "Emma",
                    LastName = "Brown",
                    PhoneNumber = "5523367354"
                },
                 new BankAccount
                {
                    Id = Guid.Parse("f4ee11a6-9d8e-4584-8d7f-8ad2d83119c5"),
                    CreatedOn = DateTime.UtcNow.AddDays(-4), // Example: Four days earlier
                    CreatedByUserId = "5",
                    FirstName = "William",
                    LastName = "Jones",
                    PhoneNumber = "5523367355"
                }
            };

            _assignmentDbContext.BankAccounts.AddRange(people);

            _assignmentDbContext.SaveChanges();
        }
        //[HttpPost]
        //public IActionResult AddBankAccount(BankAccountDto bankAccountDto)
        //{
        //    var bankAccount = new BankAccount()
        //    {
        //        Id = Guid.NewGuid(),
        //        FirstName = bankAccountDto.FirstName,
        //        LastName = bankAccountDto.LastName,
        //        PhoneNumber = bankAccountDto.PhoneNumber,
        //        Balance = bankAccountDto.Balance,
        //        CreatedByUserId = "elifokumus",
        //        CreatedOn = DateTimeOffset.UtcNow,
        //        IsDeleted = false,


        //    };

        //    _assignmentDbContext.BankAccounts.Add(bankAccount);

        //    _assignmentDbContext.SaveChanges();

        //    return Ok(bankAccount);
        //}
        [HttpPost]
        public IActionResult CreateBankAccount(BankAccountDto bankAccountDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bankAccount = new BankAccount()
            {
                Id = Guid.NewGuid(),
                FirstName = bankAccountDto.FirstName,
                LastName = bankAccountDto.LastName,
                PhoneNumber = bankAccountDto.PhoneNumber,
                Balance = bankAccountDto.Balance,
                CreatedByUserId = "elifokumus",
                CreatedOn = DateTimeOffset.UtcNow,
                IsDeleted = false,


            };

            _assignmentDbContext.BankAccounts.Add(bankAccount);

            _assignmentDbContext.SaveChanges();

            return Ok(bankAccount);
        }

        [HttpGet("[action]/(bankAccountId:guid)")]
        public GetBankAccountDataResponseModel GetBankAccount(Guid bankAccountId)
        {
            //Guid.Parse(bankAccountId);

            var bankAccount = _assignmentDbContext.BankAccounts.FirstOrDefault(x => x.Id == bankAccountId);

            var response = new GetBankAccountDataResponseModel()
            {
                FirstName = bankAccount.FirstName,
                LastName = bankAccount.LastName,
                Balance = bankAccount.Balance,
            };

            return response;
        }
    }
}
