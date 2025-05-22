using EventSourcing.Data;
using EventSourcing.Events;

namespace EventSourcing
{
    internal class Program
    {
        const string StudentId = "55BE2CDB-1B85-4986-AFA0-A848437A2B3D";

        static readonly InMemoryEventStore _eventStore = new();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var studentId = Guid.Parse(StudentId);

            // 1. Events persistieren
            PersistSomeStudentEvents(studentId);

            // 2. Student aus DomainEvents materialisieren
            MaterializeEntity(studentId);

            // 3. Student aus projezierter View laden
            var student = _eventStore.GetEntityView<StudentEntity>(studentId);
            Console.WriteLine($"Student {student.FullName} aus projezierter View.");


            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void MaterializeEntity(Guid studentId)
        {
            var student = _eventStore.GetEntity<StudentEntity>(studentId);
            Console.WriteLine($"Student {student.FullName} hat sich bei {string.Join(", ", student.EnrolledCourses)} eingeschrieben.");
        }

        private static void PersistSomeStudentEvents(Guid studentId)
        {
            var registeredEvent = new StudentRegisteredEvent
            {
                StudentId = studentId,
                FullName = "Max Mustermann",
                Email = "YtNlH@example.com",
                DateOfBirth = new DateTime(2000, 1, 1)
            };
            _eventStore.Append<StudentEntity>(registeredEvent);
            Console.WriteLine($"Student {registeredEvent.FullName} wurde registriert.");

            var enrolledEvent = new StudentEnrolledEvent
            {
                StudentId = studentId,
                CourseName = "C# für Experten"
            };
            _eventStore.Append<StudentEntity>(enrolledEvent);
            Console.WriteLine($"Student {registeredEvent.FullName} hat sich bei {enrolledEvent.CourseName} eingeschrieben.");

            var enrolledEvent2 = new StudentEnrolledEvent
            {
                StudentId = studentId,
                CourseName = "Moderne Architektur in C# und .NET"
            };
            _eventStore.Append<StudentEntity>(enrolledEvent2);
            Console.WriteLine($"Student {registeredEvent.FullName} hat sich bei {enrolledEvent2.CourseName} eingeschrieben.");

            var emailUpdatedEvent = new StudentEmailUpdatedEvent
            {
                StudentId = studentId,
                Email = "whats.up@doc.com"
            };
            _eventStore.Append<StudentEntity>(emailUpdatedEvent);
            Console.WriteLine($"Student {registeredEvent.FullName} hat seine E-Mail Adresse geändert.");
        }
    }
}
