using BLL;
using DAL;
using Entities.Abstract;
class Program
{ 
static void Main(string[] args)
{
    List<ICandidate> candidates = CandidateRepository.GetCandidates();
    List<IEmployee> employees = RecruitmentService.HireEmployees(candidates);

    Console.WriteLine("Çalışanın Email-Departman-Saatlik ücret bilgileri");
    foreach (var emp in employees)
    {
        Console.WriteLine($"Email: {emp.EMail} Departman: {emp.Department} Saatlik ücret: {emp.HourlyWage}");
    }
    

}
}