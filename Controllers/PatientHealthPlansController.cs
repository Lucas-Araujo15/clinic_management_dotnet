using clinic_management_dotnet.Data;
using clinic_management_dotnet.Dtos.PatientHealthPlan;
using clinic_management_dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace clinic_management_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Controller do Relacionamento entre Pacientes e Planos de Saúde")]
    public class PatientHealthPlansController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public PatientHealthPlansController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Associa um paciente a um plano de saúde")]
        public async Task<ActionResult<PatientHealthPlanDTO>> CreatePatientHealthPlan(CreatePatientHealthPlanDTO dto)
        {
            var healthPlan = await _context.HealthPlan.FindAsync(dto.HealthPlanId);

            var patient = await _context.Patients
                .Include(p => p.Address)
                .FirstOrDefaultAsync(p => p.Id == dto.PatientId);

            if (healthPlan == null || patient == null)
            {
                return NotFound();
            }

            var patientHealthPlan = new PatientHealthPlanModel(patient, healthPlan);

            _context.PatientHealthPlan.Add(patientHealthPlan);
            await _context.SaveChangesAsync();

            var patientHealthPlanDTO = new PatientHealthPlanDTO(patientHealthPlan);

            return CreatedAtAction("FindPatientHealthPlanById", new { id = patientHealthPlan.Id }, patientHealthPlanDTO);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todas as associações de paciente e plano de saúde")]
        public async Task<ActionResult<IEnumerable<PatientHealthPlanDTO>>> FindAllPatientHealthPlan()
        {
            return Ok(
                await _context.PatientHealthPlan
                .Include(ph => ph.Patient)
                .ThenInclude(p => p.Address)
                .Include(ph => ph.HealthPlan)
                .Select(ph => new PatientHealthPlanDTO(ph))
                .ToListAsync()
            );
        }


        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Lista uma associação de paciente e plano de saúde pelo ID")]
        public async Task<ActionResult<PatientHealthPlanDTO>> FindPatientHealthPlanById(int id)
        {
            var patientHealthPlan = await _context.PatientHealthPlan
                .Include(ph => ph.Patient)
                .ThenInclude(p => p.Address)
                .Include(ph => ph.HealthPlan)
                .FirstOrDefaultAsync(ph => ph.Id == id);

            if (patientHealthPlan == null)
            {
                return NotFound();
            }

            return Ok(new PatientHealthPlanDTO(patientHealthPlan));
        }

        [HttpGet("health-plans/{patientId}")]
        [SwaggerOperation(Summary = "Lista os planos de saúde associados a um paciente\r")]
        public async Task<ActionResult<IEnumerable<HealthPlansOfAPatientDTO>>> FindHealthPlansOfAPatient(int patientId)
        {
            return Ok(
                await _context.PatientHealthPlan
                .Include(ph => ph.HealthPlan)
                .Include(ph => ph.Patient)
                .Where(ph => ph.Patient.Id == patientId)
                .Select(ph => new HealthPlansOfAPatientDTO(ph))
                .ToListAsync()
            );
        }

        [HttpGet("patients/{healthPlanId}")]
        [SwaggerOperation(Summary = "Lista todos os pacientes associados a um plano de saúde")]
        public async Task<ActionResult<IEnumerable<PatientsOfAHealthPlanDTO>>> FindPatientsOfAHealthPlan(int healthPlanId)
        {
            return Ok(
                await _context.PatientHealthPlan
                .Include(ph => ph.HealthPlan)
                .Include(ph => ph.Patient)
                .ThenInclude(p => p.Address)
                .Where(ph => ph.HealthPlan.Id == healthPlanId)
                .Select(ph => new PatientsOfAHealthPlanDTO(ph))
                .ToListAsync()
            );
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove a associação entre um paciente e um plano de saúde")]
        public async Task<IActionResult> DeletePatientHealthPlan(int id)
        {
            var patientHealthPlan = await _context.PatientHealthPlan
                .Include(ph => ph.Patient)
                .ThenInclude(p => p.Address)
                .Include(ph => ph.HealthPlan)
                .FirstOrDefaultAsync(ph => ph.Id == id);

            if (patientHealthPlan == null)
            {
                return NotFound();
            }

            _context.PatientHealthPlan.Remove(patientHealthPlan);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
