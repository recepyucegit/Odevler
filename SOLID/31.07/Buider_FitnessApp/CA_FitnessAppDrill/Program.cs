using CA_FitnessAppDrill.Concretes;
using CA_FitnessAppDrill.Directors;

var calisthenics = new Calisthenics();
var director = new Director();

director.Construct(calisthenics);
Console.WriteLine(calisthenics.GetExercise());




