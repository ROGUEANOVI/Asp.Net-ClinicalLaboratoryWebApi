using ClinicalLaboratory.Application.UseCases.Analysis.Commands.DeleteCommand;
using ClinicalLaboratory.Application.UseCases.Analysis.Commands.EditCommand;
using ClinicalLaboratory.Application.UseCases.Analysis.Commands.RegisterCommand;
using ClinicalLaboratory.Application.UseCases.Analysis.Queries.GetAllQuery;
using ClinicalLaboratory.Application.UseCases.Analysis.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalLaboratory.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalysisController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnalysisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetListAnalysis()
        {
            var response = await _mediator.Send(new GetAllAnalysisQuery());

            if (response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAnalysisById(int id)
        {
            var response = await _mediator.Send(new GetAnalysisByIdQuery() { AnalysisId = id });

            if (response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [Authorize(Roles ="admin")]
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AnalysisRegister( [FromBody] AnalysisRegisterCommand command)
        {
            var response = await _mediator.Send(command);

            if (!response.IsSuccess)
            {
                return BadRequest(Response);
            }

            return Ok(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        [Route("edit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AnalysisEdit([FromBody] AnalysisEditCommand command)
        {
            var response = await _mediator.Send(command);

            if (!response.IsSuccess)
            {
                return BadRequest(Response);
            }

            return Ok(response);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete]
        [Route("delete/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AnalysisDelete(int id)
        {
            var response = await _mediator.Send(new AnalysisDeleteCommand() { AnalysisId = id });

            if (!response.IsSuccess)
            {
                return NotFound(Response);
            }

            return Ok(response);
        }
    }

}
