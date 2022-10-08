using Core.ViewModel;
using Digiterati.Core.Abstractions;
using Digiterati.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Digiterati.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SoftLockController : Controller
    {
        private readonly ISoftLockService _softLockService;

        public SoftLockController(ISoftLockService softLockService)
        {
            _softLockService = softLockService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Softlock))]
        public async Task<IActionResult> GetSoftLock(int LockId)
        {
            var result = await _softLockService.GetSoftLock(LockId);
            if (result != null)
                return new OkObjectResult(result);
            else
                return new NoContentResult();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Softlock))]
        public async Task<IActionResult> CreateSoftLock(SoftLockDto softLock)
        {
            await _softLockService.CreateSoftLock(softLock);
            return new OkObjectResult(softLock);
        }

        [HttpPut, Route("UpdateSoftLock")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Softlock))]
        public async Task<IActionResult> UpdateSoftLock(SoftLockDto softLock)
        {
            var result = await _softLockService.UpdateSoftLock(softLock);
            return new OkObjectResult(result);
        }

        [HttpPut, Route("DeleteSoftLock")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Softlock))]
        public async Task<IActionResult> DeleteSoftLock(int LockId)
        {
            var result = await _softLockService.DeleteSoftLock(LockId);
            return new OkObjectResult(result);
        }
    }
}
