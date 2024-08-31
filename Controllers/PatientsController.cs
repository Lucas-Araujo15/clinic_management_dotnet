using clinic_management_dotnet.Data;
using clinic_management_dotnet.Dtos.Patient;
using clinic_management_dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace clinic_management_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Controller de Pacientes")]
    public class PatientsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PatientsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os pacientes cadastrados")]
        public async Task<ActionResult<IEnumerable<PatientDTO>>> FindAllPatients()
        {
            return Ok(await _context.Patients
                .Include(p => p.Address)
                .Select(p => new PatientDTO(p))
                .ToListAsync());
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Busca um paciente por ID")]
        public async Task<ActionResult<PatientDTO>> FindPatientById(int id)
        {
            var patient = await _context.Patients
                .Include(p => p.Address)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(new PatientDTO(patient));
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo paciente\r")]
        public async Task<ActionResult<PatientDTO>> CreatePatient(CreatePatientDTO dto)
        {
            var patient = new PatientModel(dto);

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            var patientDTO = new PatientDTO(patient);

            return CreatedAtAction("FindPatientById", new {id = patient.Id}, patientDTO);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualizar os dados de um paciente existente")]
        public async Task<IActionResult> UpdatePatient(int id, UpdatePatientDTO dto)
        {
            var patient = await _context.Patients
                .Include(p => p.Address)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            patient.UpdateInformation(dto);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Exclui um paciente")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _context.Patients.Include(p => p.Address).FirstOrDefaultAsync(p => p.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            if (patient.PatientHealthPlans != null)
            {
                _context.PatientHealthPlan.RemoveRange(patient.PatientHealthPlans);
            }

            _context.Patients.Remove(patient);
            _context.Address.Remove(patient.Address);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
