using CA_InsanKaynakları.Business;
using CA_InsanKaynakları.RepositoryAndService;
using System;

class Program
{
    static void Main(string[] args)
    {
        var candidates = CandidateRepository.GetCandidates();
        var hiredEmployees = RecruitmentService.HireEmployees(candidates);

        Console.WriteLine("/////////////////////////");
        foreach (var emp in hiredEmployees)
        {
            Console.WriteLine($"Email: {emp.Email} Departman: {emp.Department} Saatlik ücret: {emp.HourlyWage}");
        }
        Console.WriteLine("/////////////////////////");
    }
}

