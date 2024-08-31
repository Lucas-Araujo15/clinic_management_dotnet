using clinic_management_dotnet.Data;
using clinic_management_dotnet.Dtos.HealthPlan;
using clinic_management_dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace clinic_management_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Controller de Planos de Saúde")]
    public class HealthPlansController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HealthPlansController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo plano de saúde\r")]
        public async Task<ActionResult<HealthPlanDTO>> CreateHealthPlan(CreateHealthPlanDTO dto)
        {
            var healthPlan = new HealthPlanModel(dto);

            _context.HealthPlan.Add(healthPlan);
            await _context.SaveChangesAsync();

            var healthPlanDTO = new HealthPlanDTO(healthPlan);

            return CreatedAtAction("FindHealthPlanById", new {id = healthPlan.Id}, healthPlanDTO);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Listar todos os planos de saúde cadastrados")]
        public async Task<ActionResult<IEnumerable<HealthPlanDTO>>> FindAllHealthPlans()
        {
            return Ok(await _context.HealthPlan
                .Select(h => new HealthPlanDTO(h))
                .ToListAsync());
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Busca um plano de saúde por ID")]
        public async Task<ActionResult<HealthPlanDTO>> FindHealthPlanById(int id)
        {
            var healthPlan = await _context.HealthPlan.FindAsync(id);

            if (healthPlan == null)
            {
                return NotFound();
            }

            return Ok(new HealthPlanDTO(healthPlan));
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza os dados de um plano de saúde existente")]
        public async Task<IActionResult> UpdateHealthPlan(int id, UpdateHealthPlanDTO dto)
        {
            var healthPlan = await _context.HealthPlan.FindAsync(id);

            if (healthPlan == null)
            {
                return NotFound();
            }

            healthPlan.UpdateInformation(dto);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Exclui um plano de saúde")]
        public async Task<IActionResult> DeleteHealthPlan(int id)
        {
            var healthPlan = _context.HealthPlan
                .Include(h => h.PatientHealthPlans)
                .FirstOrDefault(h => h.Id == id);

            if (healthPlan == null)
            {
                return NotFound();
            }

            if (healthPlan.PatientHealthPlans != null)
            {
                _context.PatientHealthPlan.RemoveRange(healthPlan.PatientHealthPlans);
            }

            _context.HealthPlan.Remove(healthPlan);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
